using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Teachers;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Teachers
{
    public class TeacherByRegistrationCodeQueryHandler : QueryHandlerBase<TeacherByRegistrationCodeQuery, TeacherByRegistrationCodeResponse>
    {
        public TeacherByRegistrationCodeQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<TeacherByRegistrationCodeResponse> Execute(TeacherByRegistrationCodeQuery query)
        {
            var teacher = await DbContext.Teachers.FirstOrDefaultAsync(t => t.RegistrationCode == query.RegistrationCode);

            if (teacher == null)
            {
                throw new EntityNotFoundException<Teacher, TeacherByRegistrationCodeQuery, TeacherByRegistrationCodeResponse>(query);
            }

            return new TeacherByRegistrationCodeResponse
            {
                LastName = teacher.LastName,
                FirstName = teacher.FirstName
            };
        }
    }
}