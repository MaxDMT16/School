using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Groups
{
    public class GroupsResponse : IQueryResult
    {
        public IEnumerable<Group> Groups { get; set; }

        public class Group
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}