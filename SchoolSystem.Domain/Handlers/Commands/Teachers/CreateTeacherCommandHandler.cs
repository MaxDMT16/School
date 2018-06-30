using System;
using System.Threading.Tasks;
using SchoolSystem.Abstractions.Contracts.Commands.Teachers;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Teachers
{
    public class CreateTeacherCommandHandler : CommandHandlerBase<CreateTeacherCommand>
    {
        public CreateTeacherCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateTeacherCommand command)
        {
            var teacher = new Teacher
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                RegistrationCode = command.RegistrationCode
            };

            DbContext.Teachers.Add(teacher);

            await DbContext.SaveChangesAsync();
        }
    }
}