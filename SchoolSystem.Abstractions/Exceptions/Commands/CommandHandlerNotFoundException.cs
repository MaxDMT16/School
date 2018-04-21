using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Commands
{
    public class CommandHandlerNotFoundException<TCommand> : CommandException<TCommand>
        where TCommand : ICommand
    {
        public CommandHandlerNotFoundException(TCommand command) : base(command)
        {
        }
    }
}