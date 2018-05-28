using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Groups
{
    public class GroupByIdQuery : IQuery<GroupResponse>
    {
        public Guid Id { get; set; }
    }
}