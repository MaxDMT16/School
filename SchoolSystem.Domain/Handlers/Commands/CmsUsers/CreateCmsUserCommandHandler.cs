using System.Threading.Tasks;
using SchoolSystem.Abstractions.Contracts.Commands.CmsUsers;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.CmsUsers
{
    public class CreateCmsUserCommandHandler : CommandHandlerBase<CreateCmsUserCommand>
    {
        public CreateCmsUserCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateCmsUserCommand command)
        {
            var cmsUser = new CmsUser
            {
                Login = command.Login,
                Password = command.Password,
                Scope = command.Scope
            };

            DbContext.CmsUsers.Add(cmsUser);

            await DbContext.SaveChangesAsync();
        }
    }
}