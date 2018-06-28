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
    public class UpdatePupilGroupCommandHandler : CommandHandlerBase<UpdatePupilGroupCommand>
    {
        public UpdatePupilGroupCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdatePupilGroupCommand command)
        {
            var pupil = await DbContext.Pupils.Where(p => p.Id == command.Id).FirstOrDefaultAsync();

            if (pupil == null)
            {
                throw new EntityNotFoundException<Pupil, UpdatePupilGroupCommand>(command);
            }

            pupil.GroupId = command.GroupId;

            await DbContext.SaveChangesAsync();
        }
    }
}