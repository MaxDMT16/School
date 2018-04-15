using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Teachers
{
    public class DeleteTeacherCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}