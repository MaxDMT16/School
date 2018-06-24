using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.User
{
    public class UserIdAndScopeByCredentialsQuery : IQuery<UserIdAndScopeResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}