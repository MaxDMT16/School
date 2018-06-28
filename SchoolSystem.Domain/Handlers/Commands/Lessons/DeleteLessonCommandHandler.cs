using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.Lessons;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
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
                throw new EntityNotFoundException<Lesson, DeleteLessonCommand>(command);
            }

            DbContext.Lessons.Remove(lesson);

            await DbContext.SaveChangesAsync();
        }
    }
}