using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Groups
{
    public class DeleteGroupCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}