using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.CmsUsers;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.CmsUsers
{
    public class UpdateCmsUserScopeCommandHandler : CommandHandlerBase<UpdateCmsUserScopeCommand>
    {
        public UpdateCmsUserScopeCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateCmsUserScopeCommand command)
        {
            var cmsUser = await DbContext.CmsUsers.FirstOrDefaultAsync(user => user.Id == command.Id);

            if (cmsUser == null)
            {
                throw new EntityNotFoundException<CmsUser, UpdateCmsUserScopeCommand>(command);
            }

            cmsUser.Scope = command.Scope;

            await DbContext.SaveChangesAsync();
        }
    }
}