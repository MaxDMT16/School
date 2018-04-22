using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.CmsUsers;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.CmsUsers
{
    public class UpdateCmsUserRefreshTokenCommandHandler : CommandHandlerBase<UpdateCmsUserRefreshTokenCommand>
    {
        public UpdateCmsUserRefreshTokenCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateCmsUserRefreshTokenCommand command)
        {
            var cmsUser = await DbContext.CmsUsers.FirstOrDefaultAsync(user => user.Id == command.Id);

            if (cmsUser == null)
            {
                throw new EntityNotFoundException<CmsUser, UpdateCmsUserRefreshTokenCommand>(command);
            }

            cmsUser.RefreshToken = command.RefreshToken;

            await DbContext.SaveChangesAsync();
        }
    }
}