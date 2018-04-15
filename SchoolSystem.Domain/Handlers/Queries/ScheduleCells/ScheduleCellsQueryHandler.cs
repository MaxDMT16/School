using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Abstractions.Contracts.Queries.ScheduleCells;
using SchoolSystem.Database.Context;
using SchoolSystem.Database.Handlers;

namespace SchoolSystem.Domain.Handlers.Queries.ScheduleCells
{
    public class ScheduleCellsQueryHandler : QueryHandlerBase<ScheduleCellsQuery, ScheduleCellsResponse>
    {
        public ScheduleCellsQueryHandler(ISchoolSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<ScheduleCellsResponse> Execute(ScheduleCellsQuery query)
        {
            var scheduleCells = await DbContext.ScheduleCells.Select(c => new ScheduleCellsResponse.ScheduleCell
            {
                Id = c.Id,
                Day = c.Day,
                LessonNumber = c.LessonNumber,
                LessonId = c.LessonId,
                Room = c.Room
            }).ToListAsync();

            return new ScheduleCellsResponse
            {
                ScheduleCells = scheduleCells
            };
        }
    }
}