using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Contracts.Queries.Lessons
{
    public class LessonsWithCellsResponse : IQueryResult
    {
        public ICollection<Lesson> Lessons { get; set; }

        public class Lesson
        {
            public Guid Id { get; set; }
            public Group Group { get; set; }
            public Teacher Teacher { get; set; }
            public Subject Subject { get; set; }
            public ICollection<ScheduleCell> ScheduleCells { get; set; }
        }

        public class Group
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public class Teacher
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class ScheduleCell
        {
            public Guid Id { get; set; }
            public int LessonNumber { get; set; }
            public DayOfWeek Day { get; set; }
            public int Room { get; set; }
        }
    }
}