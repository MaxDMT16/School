using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Teachers;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Teachers
{
    public class TeachersQueryHandler : QueryHandlerBase<TeachersQuery, TeachersResponse>
    {
        public TeachersQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<TeachersResponse> Execute(TeachersQuery query)
        {
            var teachers = await DbContext.Teachers.Select(t => new TeachersResponse.Teacher
            {
                Id = t.Id,
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                RegistrationCode = t.RegistrationCode
            }).ToListAsync();

            return new TeachersResponse
            {
                Teachers = teachers
            };
        }
    }
}