using System;
using System.Threading.Tasks;
using Autofac;
using FluentValidation;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.CQRS.Handlers;

namespace SchoolSystem.Application.Buses
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CommandBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = Resolve(command);

            await Validate(command);

            await commandHandler.Execute(command);
        }

        private ICommandHandler<TCommand> Resolve<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var commandHandler = _lifetimeScope.ResolveOptional<ICommandHandler<TCommand>>();

            if (commandHandler == null)
            {
                throw new InvalidOperationException("Can't resolve command handler");
            }

            return commandHandler;
        }

        private async Task Validate<TCommand>(TCommand command)
        {
            var validator = _lifetimeScope.ResolveOptional<IValidator<TCommand>>();

            if (validator == null)
            {
                throw new InvalidOperationException("Command validator is null");
            }

            var validationResult = await validator.ValidateAsync(command);

            if (validationResult == null)
            {
                throw new InvalidOperationException("Validation result is null");
            }

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Command is invalid state", validationResult.Errors);
            }
        }
    }
}