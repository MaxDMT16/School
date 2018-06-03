using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Lessons
{
    public class LessonByIdQuery : IQuery<LessonResponse>
    {
        public Guid Id { get; set; }
    }
}