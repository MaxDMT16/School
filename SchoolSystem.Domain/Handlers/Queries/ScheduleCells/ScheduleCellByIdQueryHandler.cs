using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.ScheduleCells;
using SchoolSystem.Abstractions.Exceptions.Queries;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Entities;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.ScheduleCells
{
    public class ScheduleCellByIdQueryHandler : QueryHandlerBase<ScheduleCellByIdQuery, ScheduleCellResponse>
    {
        public ScheduleCellByIdQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<ScheduleCellResponse> Execute(ScheduleCellByIdQuery query)
        {
            var scheduleCell = await DbContext.ScheduleCells.Where(cell => cell.Id == query.Id).FirstOrDefaultAsync();

            if (scheduleCell == null)
            {
                throw new EntityNotFoundException<ScheduleCell, ScheduleCellByIdQuery, ScheduleCellResponse>(query);
            }

            return new ScheduleCellResponse
            {
                Id = scheduleCell.Id,
                Day = scheduleCell.Day,
                LessonId = scheduleCell.LessonId,
                LessonNumber = scheduleCell.LessonNumber,
                Room = scheduleCell.Room
            };
        }
    }
}