using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.CmsUsers;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.CmsUsers
{
    public class DeleteCmsUserCommandHandler : CommandHandlerBase<DeleteCmsUserCommand>
    {
        public DeleteCmsUserCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteCmsUserCommand command)
        {
            var cmsUser = await DbContext.CmsUsers.FirstOrDefaultAsync(user => user.Id == command.Id);

            if (cmsUser == null)
            {
                throw new EntityNotFoundException<CmsUser, DeleteCmsUserCommand>(command);
            }

            DbContext.CmsUsers.Remove(cmsUser);

            await DbContext.SaveChangesAsync();
        }
    }
}