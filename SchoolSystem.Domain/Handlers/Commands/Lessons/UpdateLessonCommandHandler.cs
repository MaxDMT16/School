using System;
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
            var lesson = await DbContext.Lessons.FirstOrDefaultAsync(l => l.Id == command.Id);

            if (lesson == null)
            {
                throw new EntityNotFoundException<Lesson, UpdateLessonCommand>(command);
            }

            lesson.TeacherId = command.TeacherId ?? lesson.TeacherId;
            lesson.GroupId = command.GroupId ?? lesson.GroupId;
            lesson.Subject = command.Subject ?? lesson.Subject;

            await DbContext.SaveChangesAsync();
        }
    }
}