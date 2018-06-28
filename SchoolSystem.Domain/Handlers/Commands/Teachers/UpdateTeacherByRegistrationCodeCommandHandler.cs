using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Teachers;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Teachers
{
    public class UpdateTeacherByRegistrationCodeCommandHandler : CommandHandlerBase<UpdateTeacherByRegistrationCodeCommand>
    {
        public UpdateTeacherByRegistrationCodeCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateTeacherByRegistrationCodeCommand command)
        {
            var teacher = await DbContext.Teachers.FirstOrDefaultAsync(t => t.RegistrationCode == command.RegistrationCode);

            if (teacher == null)
            {
                throw new EntityNotFoundException<Teacher, UpdateTeacherByRegistrationCodeCommand>(command);
            }

            teacher.Email = command.Email;
            teacher.Password = command.Password;

            await DbContext.SaveChangesAsync();
        }
    }
}