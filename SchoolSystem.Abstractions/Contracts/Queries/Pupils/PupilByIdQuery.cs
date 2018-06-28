using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Pupils
{
    public class PupilByIdQuery : IQuery<PupilWithGroupResponse>
    {
        public Guid Id { get; set; }
    }
}