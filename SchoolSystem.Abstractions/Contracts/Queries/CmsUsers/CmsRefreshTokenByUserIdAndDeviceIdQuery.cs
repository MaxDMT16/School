using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.CmsUsers
{
    public class CmsRefreshTokenByUserIdAndDeviceIdQuery : IQuery<CmsRefreshTokenResponse>
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
    }
}