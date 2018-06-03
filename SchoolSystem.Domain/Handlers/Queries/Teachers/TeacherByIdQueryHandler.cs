using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Teachers;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities.Users;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Teachers
{
    public class TeacherByIdQueryHandler : QueryHandlerBase<TeacherByIdQuery, TeacherResponse>
    {
        public TeacherByIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<TeacherResponse> Execute(TeacherByIdQuery query)
        {
            var resultTeacher = await DbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == query.Id);

            if (resultTeacher == null)
            {
                throw new EntityNotFoundException<Teacher, TeacherByIdQuery, TeacherResponse>(query);
            }

            return new TeacherResponse
            {
                Id = resultTeacher.Id,
                LastName = resultTeacher.LastName,
                FirstName = resultTeacher.FirstName
            };
        }
    }
}