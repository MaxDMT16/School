using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.User
{
    public class SetUserRefreshTokenCommand : ICommand
    {
        public Guid Id { get; set; }
        public string RefreshToken { get; set; }
        public string DeviceId { get; set; }
    }
}