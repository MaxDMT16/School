using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.ScheduleCells;
using SchoolSystem.Abstractions.Contracts.Queries.ScheduleCells;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/schedule-cell")]
    public class AdminScheduleCellController : SchoolSystemController
    {
        public AdminScheduleCellController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreateScheduleCell(CreateScheduleCellCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        public async Task UpdateScheduleCell(UpdateScheduleCellCommand command)
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
    }
}