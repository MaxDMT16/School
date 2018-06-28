using SchoolSystem.Abstractions.CQRS.Contracts;

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