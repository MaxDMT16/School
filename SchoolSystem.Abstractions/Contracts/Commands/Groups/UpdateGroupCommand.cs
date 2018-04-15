using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Groups
{
    public class UpdateGroupCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}