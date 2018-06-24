using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.CmsUsers
{
    public class CmsRefreshTokenResponse : IQueryResult
    {
        public string RefreshToken { get; set; }
    }
}