using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Pupils
{
    public class PupilWithGroupResponse : IQueryResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public PupilGroup Group { get; set; }

        public class PupilGroup
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}