using System;
using SchoolSystem.Abstractions.Enums;

namespace SchoolSystem.Abstractions.Authorization.Services
{
    public abstract class UserTokenPayloadBase : Payload
    {
        public Guid UserId { get; set; }
        public string DeviceId { get; set; }
    }
}