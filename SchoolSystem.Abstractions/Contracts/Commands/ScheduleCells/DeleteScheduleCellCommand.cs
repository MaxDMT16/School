using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.ScheduleCells
{
    public class DeleteScheduleCellCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}