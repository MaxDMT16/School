using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Lessons;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Lessons
{
    public class
        LessonByGroupIdQueryHandler : QueryHandlerBase<LessonsByGroupIdQuery, LessonsWithCellsResponse
        > //todo: refactor with dapper
    {
        public LessonByGroupIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<LessonsWithCellsResponse> Execute(LessonsByGroupIdQuery query)
        {
            var lessons = await DbContext.TeachersLessons
                .Include(teacherLesson => teacherLesson.Lesson)
                .Include(teacherLesson => teacherLesson.Lesson.Group)
                .Include(teacherLesson => teacherLesson.Teacher)
                .Where(teacherLesson => teacherLesson.Lesson.GroupId == query.Id)
                .Select(teacherLesson => new LessonsWithCellsResponse.Lesson
                {
                    Id = teacherLesson.LessonId,
                    Teacher = new LessonsWithCellsResponse.Teacher
                    {
                        Id = teacherLesson.Teacher.Id,
                        LastName = teacherLesson.Teacher.LastName,
                        FirstName = teacherLesson.Teacher.FirstName
                    },
                    Group = new LessonsWithCellsResponse.Group
                    {
                        Id = teacherLesson.Lesson.Group.Id,
                        Name = teacherLesson.Lesson.Group.Name
                    },
                    Subject = new LessonsWithCellsResponse.Subject
                    {
                        Id = teacherLesson.Lesson.Subject.Id,
                        Name = teacherLesson.Lesson.Subject.Name
                    },
                    ScheduleCells = teacherLesson.Lesson.ScheduleCells.Select(cell =>
                        new LessonsWithCellsResponse.ScheduleCell
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