using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.Groups;
using SchoolSystem.Abstractions.Contracts.Queries.Groups;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/group")]
    [OAuth(ScopeFlag.Admin)]
    public class AdminGroupController : SchoolSystemController
    {
        public AdminGroupController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreateGroup(CreateGroupCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        public async Task UpdateGroup(UpdateGroupCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        public async Task DeleteGroup(DeleteGroupCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpGet]
        public async Task<GroupsResponse> GetAllGroups()
        {
            var groupsResponse = await QueryBus.Execute<GroupsQuery, GroupsResponse>(new GroupsQuery());

            return groupsResponse;
        }
    }
}