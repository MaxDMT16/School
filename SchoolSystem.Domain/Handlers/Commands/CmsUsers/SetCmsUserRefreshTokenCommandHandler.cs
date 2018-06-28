using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.CmsUsers;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.CmsUsers
{
    public class SetCmsUserRefreshTokenCommandHandler : CommandHandlerBase<SetCmsUserRefreshTokenCommand>
    {
        public SetCmsUserRefreshTokenCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(SetCmsUserRefreshTokenCommand command)
        {
            var refreshToken = await DbContext.CmsUserRefreshTokens
                .FirstOrDefaultAsync(token => token.CmsUserId == command.Id && token.DeviceId == command.DeviceId);

            if (refreshToken == null)
            {
                DbContext.CmsUserRefreshTokens.Add(new CmsUserRefreshToken
                {
                    Token = command.RefreshToken,
                    CmsUserId = command.Id,
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