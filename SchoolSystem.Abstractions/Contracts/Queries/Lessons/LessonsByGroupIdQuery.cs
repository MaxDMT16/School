using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Lessons
{
    public class LessonsByGroupIdQuery : IQuery<LessonsWithCellsResponse>
    {
        public Guid Id { get; set; }
    }
}