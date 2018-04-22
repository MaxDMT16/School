using System;
using SchoolSystem.Abstractions.Authorization.Services;

namespace SchoolSystem.Domain.Authorization.Services
{
    public class CmsTokenPayload : Payload
    {
        public Guid UserId { get; set; }
    }
}