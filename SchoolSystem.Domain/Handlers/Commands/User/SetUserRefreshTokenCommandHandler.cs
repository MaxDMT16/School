using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.User;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.User
{
    public class SetUserRefreshTokenCommandHandler : CommandHandlerBase<SetUserRefreshTokenCommand>
    {
        public SetUserRefreshTokenCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(SetUserRefreshTokenCommand command)
        {
            var refreshToken = await DbContext.UserRefreshTokens.FirstOrDefaultAsync(token =>
                token.UserId == command.Id && token.DeviceId == command.DeviceId);

            if (refreshToken == null)
            {
                DbContext.UserRefreshTokens.Add(new UserRefreshToken
                {
                    Token = command.RefreshToken,
                    UserId = command.Id,
                    DeviceId = command.DeviceId
                });
            }
            else
            {
                refreshToken.Token = command.RefreshToken;
            }

            await DbContext.SaveChangesAsync();
        }
    }
}