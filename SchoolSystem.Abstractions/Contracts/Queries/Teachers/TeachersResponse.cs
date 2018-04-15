using System;
using System.Collections.Generic;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Teachers
{
    public class TeachersResponse : IQueryResult
    {
        public IEnumerable<Teacher> Teachers { get; set; }

        public class Teacher
        {
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}