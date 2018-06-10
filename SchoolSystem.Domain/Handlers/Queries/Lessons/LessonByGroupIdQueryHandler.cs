using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Lessons;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Lessons
{
    public class LessonByGroupIdQueryHandler : QueryHandlerBase<LessonsByGroupIdQuery, LessonsWithCellsResponse>
    {
        public LessonByGroupIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<LessonsWithCellsResponse> Execute(LessonsByGroupIdQuery query)
        {
            var lessons = await DbContext.Lessons
                .Include(lesson => lesson.Group)
                .Include(lesson => lesson.Teacher)
                .Include(lesson => lesson.ScheduleCells)
                .Where(lesson => lesson.GroupId == query.Id)
                .Select(lesson => new LessonsWithCellsResponse.Lesson
                {
                    Id = lesson.Id,
                    Teacher = new LessonsWithCellsResponse.Teacher
                    {
                        Id = lesson.Teacher.Id,
                        LastName = lesson.Teacher.LastName,
                        FirstName = lesson.Teacher.FirstName
                    },
                    Group = new LessonsWithCellsResponse.Group
                    {
                        Id = lesson.Group.Id,
                        Name = lesson.Group.Name
                    },
                    Subject = lesson.Subject,
                    ScheduleCells = lesson.ScheduleCells.Select(cell => new LessonsWithCellsResponse.ScheduleCell
                    {
                        Id = cell.Id,
                        Day = cell.Day,
                        LessonNumber = cell.LessonNumber,
                        Room = cell.Room
                    }).ToList()
                }).ToListAsync();

            return new LessonsWithCellsResponse
            {
                Lessons = lessons
            };
        }
    }
}