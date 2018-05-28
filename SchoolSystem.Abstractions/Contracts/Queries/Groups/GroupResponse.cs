using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Groups
{
    public class GroupResponse : IQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}