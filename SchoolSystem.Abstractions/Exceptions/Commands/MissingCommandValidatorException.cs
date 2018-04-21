using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Exceptions.Commands
{
    public class MissingCommandValidatorException<TCommand> : CommandException<TCommand>
        where TCommand : ICommand
    {
        public MissingCommandValidatorException(TCommand command) : base(command)
        {
        }
    }
}