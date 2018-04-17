using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Commands.ScheduleCells;
using SchoolSystem.Abstractions.Exceptions.Commands;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Commands.ScheduleCells
{
    public class DeleteScheduleCellCommandHandler : CommandHandlerBase<DeleteScheduleCellCommand>
    {
        public DeleteScheduleCellCommandHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteScheduleCellCommand command)
        {
            var scheduleCell = await DbContext.ScheduleCells.FirstOrDefaultAsync(c => c.Id == command.Id);

            if (scheduleCell == null)
            {
                throw new EntityNotFoundException<ScheduleCell, DeleteScheduleCellCommand>(command);
            }

            DbContext.ScheduleCells.Remove(scheduleCell);

            await DbContext.SaveChangesAsync();
        }
    }
}