using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Queries.User
{
    public class UserRefreshTokenByUserIdAndDeviceIdQuery : IQuery<UserRefreshTokenResponse>
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
    }
}