using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.Lessons;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.Lessons
{
    public class LessonByIdQueryHandler : QueryHandlerBase<LessonByIdQuery, LessonResponse>
    {
        public LessonByIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<LessonResponse> Execute(LessonByIdQuery query)
        {
            var resultLesson = await DbContext.Lessons
                .Include(lesson => lesson.Subject)
                .Include(lesson => lesson.TeachersLessons)
                .FirstOrDefaultAsync(lesson => lesson.Id == query.Id);

            if (resultLesson == null)
            {
                throw new EntityNotFoundException<Lesson, LessonByIdQuery, LessonResponse>(query);
            }

            return new LessonResponse
            {
                Id = resultLesson.Id,
                GroupId = resultLesson.GroupId,
                Subject = new LessonResponse.SubjectInfo
                {
                    Id = resultLesson.SubjectId,
                    Name = resultLesson.Subject.Name
                },
                TeacherIds = resultLesson.TeachersLessons.Select(teacherLesson => teacherLesson.TeacherId).ToList()
            };
        }
    }
}