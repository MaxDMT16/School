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
            public Group Group { get; set; }
            public Teacher Teacher { get; set; }
            public Subject Subject { get; set; }
        }

        public class Group
        {
            public string Name { get; set; }
        }

        public class Teacher
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}