using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Lessons;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.Lessons
{
    public class DeleteLessonCommandHandler : CommandHandlerBase<DeleteLessonCommand>
    {
        public DeleteLessonCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteLessonCommand command)
        {
            var lesson = await DbContext.Lessons.FirstOrDefaultAsync(l => l.Id == command.Id);

            if (lesson == null)
            {
                throw new InvalidOperationException("Can't find lesson to delete");
            }

            DbContext.Lessons.Remove(lesson);

            await DbContext.SaveChangesAsync();
        }
    }
}