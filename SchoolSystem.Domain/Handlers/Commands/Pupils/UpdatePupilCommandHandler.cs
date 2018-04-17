using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Pupils;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Pupils
{
    public class UpdatePupilCommandHandler : CommandHandlerBase<UpdatePupilCommand>
    {
        public UpdatePupilCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdatePupilCommand command)
        {
            var pupil = await DbContext.Pupils.Where(p => p.Id == command.Id).FirstOrDefaultAsync();

            if (pupil == null)
            {
                throw new EntityNotFoundException<Pupil, UpdatePupilCommand>(command);
            }

            pupil.FirstName = command.FirstName ?? pupil.FirstName;
            pupil.LastName = command.LastName ?? pupil.LastName;

            await DbContext.SaveChangesAsync();
        }
    }
}