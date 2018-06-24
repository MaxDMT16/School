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
    [OAuth(Scope.Admin)]
    public class AdminGroupController : CmsUserControllerBase
    {
        public AdminGroupController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreateGroup([FromBody] CreateGroupCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        public async Task UpdateGroup([FromBody] UpdateGroupCommand command)
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

        [HttpGet]
        [Route("{id}")]
        public async Task<GroupResponse> GetGroupById(Guid id)
        {
            var groupResponse = await QueryBus.Execute<GroupByIdQuery, GroupResponse>(new GroupByIdQuery
            {
                Id = id
            });

            return groupResponse;
        }
    }
}