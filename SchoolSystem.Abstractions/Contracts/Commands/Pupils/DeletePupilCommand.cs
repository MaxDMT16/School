using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Pupils
{
    public class DeletePupilCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}