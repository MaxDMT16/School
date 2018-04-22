using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.CmsUsers
{
    public class
        CmsUserIdAndScopeByCredentialsQueryHandler : QueryHandlerBase<CmsUserIdAndScopeByCredentialsQuery,
            CmsUserIdAndScopeResponse>
    {
        public CmsUserIdAndScopeByCredentialsQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<CmsUserIdAndScopeResponse> Execute(CmsUserIdAndScopeByCredentialsQuery query)
        {
            var cmsUser = await DbContext.CmsUsers.FirstOrDefaultAsync(user =>
                user.Login == query.Login && user.Password == query.Password);

            if (cmsUser == null)
            {
                throw new EntityNotFoundException<CmsUser, CmsUserIdAndScopeByCredentialsQuery,
                    CmsUserIdAndScopeResponse>(query);
            }

            return new CmsUserIdAndScopeResponse
            {
                Id = cmsUser.Id,
                Scope = cmsUser.Scope
            };
        }
    }
}