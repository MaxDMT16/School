using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Teachers
{
    public class TeacherByIdQuery : IQuery<TeacherResponse>
    {
        public Guid Id { get; set; }
    }
}