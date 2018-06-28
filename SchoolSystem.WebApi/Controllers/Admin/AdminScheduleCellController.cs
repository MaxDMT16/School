using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.ScheduleCells;
using SchoolSystem.Abstractions.Contracts.Queries.ScheduleCells;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/schedule-cell")]
    [OAuth(Scope.Admin)]
    public class AdminScheduleCellController : CmsUserControllerBase
    {
        public AdminScheduleCellController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreateScheduleCell([FromBody] CreateScheduleCellCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        public async Task UpdateScheduleCell([FromBody] UpdateScheduleCellCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        public async Task DeleteScheduleCell(DeleteScheduleCellCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpGet]
        public async Task<ScheduleCellsResponse> GetAllScheduleCells()
        {
            var scheduleCellsResponse =
                await QueryBus.Execute<ScheduleCellsQuery, ScheduleCellsResponse>(new ScheduleCellsQuery());

            return scheduleCellsResponse;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ScheduleCellResponse> GetCellById(Guid id)
        {
            var scheduleCellResponse = await QueryBus.Execute<ScheduleCellByIdQuery, ScheduleCellResponse>(new ScheduleCellByIdQuery
            {
                Id = id
            });

            return scheduleCellResponse;
        }
    }
}