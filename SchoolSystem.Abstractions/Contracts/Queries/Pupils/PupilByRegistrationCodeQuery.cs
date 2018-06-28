using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Pupils
{
    public class PupilByRegistrationCodeQuery : IQuery<PupilByRegistrationCodeResponse>
    {
        public Guid RegistrationCode { get; set; }
    }
}