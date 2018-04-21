using System;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Exceptions.Attributes;

namespace SchoolSystem.Abstractions.Exceptions.Commands
{
    public class EntityNotFoundException<TEntity, TCommand> : CommandException<TCommand>
        where TCommand : ICommand
    {
        public EntityNotFoundException(TCommand command) : base(command)
        {
        }

        [Log] public Type EntityType => typeof(TEntity);
    }
}