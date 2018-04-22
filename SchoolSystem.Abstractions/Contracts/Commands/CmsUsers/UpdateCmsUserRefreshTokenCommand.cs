using System;
using SchoolSystem.Abstractions.CQRS.Contracts;

namespace SchoolSystem.Abstractions.Contracts.Commands.CmsUsers
{
    public class UpdateCmsUserRefreshTokenCommand : ICommand
    {
        public Guid Id { get; set; }
        public string RefreshToken { get; set; }
    }
}