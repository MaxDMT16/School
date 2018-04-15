using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Lessons;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Lessons
{
    public class LessonsQueryHandler : QueryHandlerBase<LessonsQuery, LessonsResponse>
    {
        public LessonsQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<LessonsResponse> Execute(LessonsQuery query)
        {
            var lessons = await DbContext.Lessons.Include(l => l.Group)
                .Include(l => l.Teacher)
                .Select(l => new LessonsResponse.Lesson
                {
                    Id = l.Id,
                    Teacher = l.Teacher != null
                        ? new LessonsResponse.Teacher
                        {
                            FirstName = l.Teacher.FirstName,
                            LastName = l.Teacher.LastName
                        }
                        : null,
                    Group = l.Group != null
                        ? new LessonsResponse.Group
                        {
                            Name = l.Group.Name
                        }
                        : null,
                    Subject = l.Subject
                }).ToListAsync();

            return new LessonsResponse
            {
                Lessons = lessons
            };
        }
    }
}