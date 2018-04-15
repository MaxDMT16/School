using System;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Contracts.Commands.Lessons
{
    public class UpdateLessonCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid? GroupId { get; set; }
        public Subject? Subject { get; set; }
    }
}