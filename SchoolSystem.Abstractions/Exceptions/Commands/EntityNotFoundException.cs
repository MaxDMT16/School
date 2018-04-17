using System;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Commands
{
    public class EntityNotFoundException<TEntity, TCommand> : CommandException<TCommand>
        where TCommand : ICommand
    {
        public EntityNotFoundException(ICommand command) : base(command)
        {
        }

        [Log] public Type EntityType => typeof(TEntity);
    }
}