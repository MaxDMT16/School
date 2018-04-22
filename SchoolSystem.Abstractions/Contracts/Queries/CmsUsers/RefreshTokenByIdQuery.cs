using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.CmsUsers
{
    public class RefreshTokenByIdQuery : IQuery<RefreshTokenResponse>
    {
        public Guid Id { get; set; }
    }
}