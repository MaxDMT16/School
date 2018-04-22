using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.Pupils;
using SchoolSystem.Abstractions.Contracts.Queries.Pupils;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/pupil")]
    [OAuth(ScopeFlag.Admin)]
    public class AdminPupilController : SchoolSystemController
    {
        public AdminPupilController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreatePupil(CreatePupilCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        public async Task UpdatePupil(UpdatePupilCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        [Route("group")]
        public async Task UpdatePupilGroup(UpdatePupilGroupCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        public async Task DeletePupil(DeletePupilCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpGet]
        public async Task<PupilsResponse> GetAllPupils()
        {
            var pupilsResponse = await QueryBus.Execute<PupilsQuery, PupilsResponse>(new PupilsQuery());

            return pupilsResponse;
        }
    }
}