﻿using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Lessons
{
    public class LessonsResponse : IQueryResult
    {
        public IEnumerable<Lesson> Lessons { get; set; }

        public class Lesson
        {
            public Guid Id { get; set; }
            public Guid GroupId { get; set; }
            public ICollection<Guid> TeacherIds { get; set; }
            public Guid SubjectId { get; set; }
        }
    }
}