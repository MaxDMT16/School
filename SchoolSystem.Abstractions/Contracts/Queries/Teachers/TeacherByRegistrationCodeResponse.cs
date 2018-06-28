using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.Teachers
{
    public class TeacherByRegistrationCodeResponse : IQueryResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}