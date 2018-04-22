using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.CmsUsers
{
    public class RefreshTokenResponse : IQueryResult
    {
        public string RefreshToken { get; set; }
    }
}