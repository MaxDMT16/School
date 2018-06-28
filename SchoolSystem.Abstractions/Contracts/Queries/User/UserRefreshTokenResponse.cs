using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.User
{
    public class UserRefreshTokenResponse : IQueryResult
    {
        public string RefreshToken { get; set; }
    }
}