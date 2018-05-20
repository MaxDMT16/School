using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Pupils
{
    public class PupilByIdQuery : IQuery<PupilResponse>
    {
        public Guid Id { get; set; }
    }
}