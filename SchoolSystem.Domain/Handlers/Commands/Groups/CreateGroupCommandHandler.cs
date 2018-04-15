using System.Threading.Tasks;
using SchoolSystem.Abstractions.Contracts.Commands.Groups;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Groups
{
    public class CreateGroupCommandHandler : CommandHandlerBase<CreateGroupCommand>
    {
        public CreateGroupCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateGroupCommand command)
        {
            var group = new Group
            {
                Name = command.Name
            };

            DbContext.Groups.Add(group);

            await DbContext.SaveChangesAsync();
        }
    }
}