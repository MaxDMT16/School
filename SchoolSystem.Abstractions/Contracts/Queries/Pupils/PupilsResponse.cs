using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Pupils
{
    public class PupilsResponse : IQueryResult
    {
        public IEnumerable<Pupil> Pupils { get; set; }

        public class Pupil
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Guid GroupId { get; set; }
        }
    }
}