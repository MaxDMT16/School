using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Contracts.Queries.Lessons
{
    public class LessonsResponse : IQueryResult
    {
        public IEnumerable<Lesson> Lessons { get; set; }

        public class Lesson
        {
            public Guid Id { get; set; }
            public Guid GroupId { get; set; }
            public Guid TeacherId { get; set; }
            public Subject Subject { get; set; }
        }
    }
}