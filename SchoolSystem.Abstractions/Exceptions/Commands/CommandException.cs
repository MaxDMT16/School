using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Commands
{
    public abstract class CommandException<TCommand> : SchoolSystemException
        where TCommand : ICommand
    {
        protected CommandException(TCommand command)
        {
            Command = command;
        }

        [Log] public TCommand Command { get; }
    }
}