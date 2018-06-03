using System;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Contracts.Queries.Lessons
{
    public class LessonResponse : IQueryResult
    {
        public Guid Id { get; set; }

        public Guid TeacherId { get; set; }
        
        public Guid GroupId { get; set; }

        public Subject Subject { get; set; }
    }
}