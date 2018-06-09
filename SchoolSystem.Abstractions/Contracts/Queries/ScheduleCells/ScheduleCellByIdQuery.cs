using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.ScheduleCells
{
    public class ScheduleCellByIdQuery : IQuery<ScheduleCellResponse>
    {
        public Guid Id { get; set; }
    }
}