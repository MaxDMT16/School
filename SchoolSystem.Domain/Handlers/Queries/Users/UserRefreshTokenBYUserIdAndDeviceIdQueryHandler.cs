using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.User;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Users
{
    public class
        UserRefreshTokenBYUserIdAndDeviceIdQueryHandler : QueryHandlerBase<UserRefreshTokenByUserIdAndDeviceIdQuery,
            UserRefreshTokenResponse>
    {
        public UserRefreshTokenBYUserIdAndDeviceIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<UserRefreshTokenResponse> Execute(UserRefreshTokenByUserIdAndDeviceIdQuery query)
        {
            var refreshToken =
                await DbContext.UserRefreshTokens.FirstOrDefaultAsync(t =>
                    t.UserId == query.Id && t.DeviceId == query.DeviceId);

            if (refreshToken == null)
            {
                throw new EntityNotFoundException<UserRefreshToken, UserRefreshTokenByUserIdAndDeviceIdQuery,
                    UserRefreshTokenResponse>(query);
            }

            return new UserRefreshTokenResponse
            {
                RefreshToken = refreshToken.Token
            };
        }
    }
}