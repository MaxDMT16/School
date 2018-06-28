using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.User
{
    public class UserIdAndScopeByCredentialsQuery : IQuery<UserIdAndScopeResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}