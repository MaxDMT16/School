using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.ScheduleCells
{
    public class ScheduleCellResponse : IQueryResult
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public int LessonNumber { get; set; }
        public DayOfWeek Day { get; set; }
        public int Room { get; set; }
    }
}