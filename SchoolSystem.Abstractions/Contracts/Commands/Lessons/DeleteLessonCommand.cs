using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.Lessons
{
    public class DeleteLessonCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}