using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.CmsUsers
{
    public class CmsUserIdAndScopeByCredentialsQuery : IQuery<CmsUserIdAndScopeResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}