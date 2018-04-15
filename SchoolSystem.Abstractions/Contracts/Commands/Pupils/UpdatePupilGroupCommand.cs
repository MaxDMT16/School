using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Pupils
{
    public class UpdatePupilGroupCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
    }
}