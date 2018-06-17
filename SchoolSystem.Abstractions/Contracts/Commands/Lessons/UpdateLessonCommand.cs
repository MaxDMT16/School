using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Contracts.Commands.Lessons
{
    public class UpdateLessonCommand : ICommand
    {
        public Guid Id { get; set; }
        public ICollection<Guid> TeacherIds { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? SubjectId { get; set; }
    }
}