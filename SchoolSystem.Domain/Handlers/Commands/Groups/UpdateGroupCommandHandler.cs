using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Groups;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Groups
{
    public class UpdateGroupCommandHandler : CommandHandlerBase<UpdateGroupCommand>
    {
        public UpdateGroupCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateGroupCommand command)
        {
            var group = await DbContext.Groups.FirstOrDefaultAsync(g => g.Id == command.Id);

            if (group == null)
            {
                throw new InvalidOperationException("Can't find group to update");
            }

            group.Name = command.Name ?? group.Name;

            await DbContext.SaveChangesAsync();
        }
    }
}