using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Teachers
{
    public class TeacherByRegistrationCodeQuery : IQuery<TeacherByRegistrationCodeResponse>
    {
        public Guid RegistrationCode { get; set; }
    }
}