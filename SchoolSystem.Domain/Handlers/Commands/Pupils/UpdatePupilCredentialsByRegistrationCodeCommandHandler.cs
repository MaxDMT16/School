using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Pupils;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Pupils
{
    public class UpdatePupilCredentialsByRegistrationCodeCommandHandler : 
        CommandHandlerBase<UpdatePupilCredentialsByRegistrationCodeCommand>
    {
        public UpdatePupilCredentialsByRegistrationCodeCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdatePupilCredentialsByRegistrationCodeCommand command)
        {
            var pupil = await DbContext.Pupils.FirstOrDefaultAsync(p => p.RegistrationCode == command.RegistrationCode);

            if (pupil == null)
            {
                throw new EntityNotFoundException<Pupil, UpdatePupilCredentialsByRegistrationCodeCommand>(command);
            }

            pupil.Email = command.Email;
            pupil.Password = command.Password;

            await DbContext.SaveChangesAsync();
        }
    }
}