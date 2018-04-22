using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.CmsUsers
{
    public class RefreshTokenByIdQueryHandler : QueryHandlerBase<RefreshTokenByIdQuery, RefreshTokenResponse>
    {
        public RefreshTokenByIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<RefreshTokenResponse> Execute(RefreshTokenByIdQuery query)
        {
            var cmsUser = await DbContext.CmsUsers.FirstOrDefaultAsync(user => user.Id == query.Id);

            if (cmsUser == null)
            {
                throw new EntityNotFoundException<CmsUser, RefreshTokenByIdQuery, RefreshTokenResponse>(query);
            }

            return new RefreshTokenResponse
            {
                RefreshToken = cmsUser.RefreshToken
            };
        }
    }
}