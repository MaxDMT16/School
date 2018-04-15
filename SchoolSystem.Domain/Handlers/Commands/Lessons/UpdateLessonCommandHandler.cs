using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Lessons;
using SchoolSystem.Database.Context;
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
                throw new InvalidOperationException("Can't find lesson to update");
            }

            lesson.TeacherId = command.TeacherId ?? lesson.TeacherId;
            lesson.GroupId = command.GroupId ?? lesson.GroupId;
            lesson.Subject = command.Subject ?? lesson.Subject;

            await DbContext.SaveChangesAsync();
        }
    }
}