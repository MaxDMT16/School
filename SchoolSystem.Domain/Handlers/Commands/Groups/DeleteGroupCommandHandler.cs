using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Groups;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Groups
{
    public class DeleteGroupCommandHandler : CommandHandlerBase<DeleteGroupCommand>
    {
        public DeleteGroupCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteGroupCommand command)
        {
            var group = await DbContext.Groups.FirstOrDefaultAsync(g => g.Id == command.Id);

            if (group == null)
            {
                throw new InvalidOperationException("Can't find group to delete");
            }

            DbContext.Groups.Remove(group);

            await DbContext.SaveChangesAsync();
        }
    }
}