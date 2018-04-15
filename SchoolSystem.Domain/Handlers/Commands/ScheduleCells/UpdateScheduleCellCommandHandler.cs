using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.ScheduleCells;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.ScheduleCells
{
    public class UpdateScheduleCellCommandHandler : CommandHandlerBase<UpdateScheduleCellCommand>
    {
        public UpdateScheduleCellCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateScheduleCellCommand command)
        {
            var scheduleCell = await DbContext.ScheduleCells.FirstOrDefaultAsync(c => c.Id == command.Id);

            if (scheduleCell == null)
            {
                throw new InvalidOperationException("Can't find schedule cell to update");
            }

            scheduleCell.Day = command.Day ?? scheduleCell.Day;
            scheduleCell.LessonId = command.LessonId ?? scheduleCell.LessonId;
            scheduleCell.LessonNumber = command.LessonNumber ?? scheduleCell.LessonNumber;
            scheduleCell.Room = command.Room ?? scheduleCell.Room;

            await DbContext.SaveChangesAsync();
        }
    }
}