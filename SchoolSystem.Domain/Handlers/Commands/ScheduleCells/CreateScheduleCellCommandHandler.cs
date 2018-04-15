using System.Threading.Tasks;
using SchoolSystem.Abstractions.Contracts.Commands.ScheduleCells;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.ScheduleCells
{
    public class CreateScheduleCellCommandHandler : CommandHandlerBase<CreateScheduleCellCommand>
    {
        public CreateScheduleCellCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateScheduleCellCommand command)
        {
            var scheduleCell = new ScheduleCell
            {
                Day = command.Day,
                LessonId = command.LessonId,
                LessonNumber = command.LessonNumber,
                Room = command.Room
            };

            DbContext.ScheduleCells.Add(scheduleCell);

            await DbContext.SaveChangesAsync();
        }
    }
}