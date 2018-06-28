using System;
using System.Threading.Tasks;
using SchoolSystem.Abstractions.Contracts.Commands.Pupils;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Pupils
{
    public class CreatePupilCommandHandler : CommandHandlerBase<CreatePupilCommand>
    {
        public CreatePupilCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreatePupilCommand command)
        {
            var pupil = new Pupil
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                GroupId = command.GroupId,
                RegistrationCode = Guid.NewGuid()
            };

            DbContext.Pupils.Add(pupil);

            await DbContext.SaveChangesAsync();
        }
    }
}