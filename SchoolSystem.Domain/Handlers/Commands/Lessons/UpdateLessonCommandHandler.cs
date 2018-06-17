using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Lessons;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Lessons
{
    public class UpdateLessonCommandHandler : CommandHandlerBase<UpdateLessonCommand>
    {
        public UpdateLessonCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateLessonCommand command)
        {
            var lesson = await DbContext.Lessons
                .Include(l => l.TeachersLessons)
                .FirstOrDefaultAsync(l => l.Id == command.Id);

            if (lesson == null)
            {
                throw new EntityNotFoundException<Lesson, UpdateLessonCommand>(command);
            }

            if (command.TeacherIds != null)
            {
                var teachersIds = lesson.TeachersLessons
                    .Select(teacherLesson => teacherLesson.TeacherId);

                var teacherIdsToDeleteFromTeachersLessons = teachersIds.Except(command.TeacherIds).ToList();

                var teacherLessonsToDelete = lesson.TeachersLessons.Where(teacherLesson =>
                    teacherIdsToDeleteFromTeachersLessons.Contains(teacherLesson.TeacherId)).ToList();

                DbContext.TeachersLessons.RemoveRange(teacherLessonsToDelete);

                var teacherIdsToAdd = command.TeacherIds.Except(teachersIds).ToList();

                foreach (var teacherId in teacherIdsToAdd)
                {
                    lesson.TeachersLessons.Add(new TeacherLesson
                    {
                        TeacherId = teacherId
                    });
                }
            }

            lesson.GroupId = command.GroupId ?? lesson.GroupId;
            lesson.SubjectId = command.SubjectId ?? lesson.SubjectId;

            await DbContext.SaveChangesAsync();
        }
    }
}