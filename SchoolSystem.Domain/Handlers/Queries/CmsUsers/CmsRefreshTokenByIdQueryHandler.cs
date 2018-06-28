using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.CmsUsers
{
    public class CmsRefreshTokenByIdQueryHandler : QueryHandlerBase<CmsRefreshTokenByUserIdAndDeviceIdQuery, CmsRefreshTokenResponse>
    {
        public CmsRefreshTokenByIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<CmsRefreshTokenResponse> Execute(CmsRefreshTokenByUserIdAndDeviceIdQuery query)
        {
            var refreshToken = await DbContext.CmsUserRefreshTokens
                .FirstOrDefaultAsync(token => token.CmsUserId == query.Id && token.DeviceId == query.DeviceId);

            if (refreshToken == null)
            {
                throw new EntityNotFoundException<CmsUser, CmsRefreshTokenByUserIdAndDeviceIdQuery, CmsRefreshTokenResponse>(query);
            }

            return new CmsRefreshTokenResponse
            {
                RefreshToken = refreshToken.Token
            };
        }
    }
}