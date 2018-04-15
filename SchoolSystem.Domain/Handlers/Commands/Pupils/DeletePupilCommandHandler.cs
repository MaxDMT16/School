using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Pupils;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Pupils
{
    public class DeletePupilCommandHandler : CommandHandlerBase<DeletePupilCommand>
    {
        public DeletePupilCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeletePupilCommand command)
        {
            var pupil = await DbContext.Pupils.FirstOrDefaultAsync(p => p.Id == command.Id);

            if (pupil == null)
            {
                throw new InvalidOperationException("Can't find pupil to delete");
            }

            DbContext.Pupils.Remove(pupil);

            await DbContext.SaveChangesAsync();
        }
    }
}