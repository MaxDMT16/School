using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.Teachers;
using SchoolSystem.Abstractions.Contracts.Queries.Teachers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/teacher")]
    [OAuth(ScopeFlag.Admin)]
    public class AdminTeacherController : SchoolSystemController
    {
        public AdminTeacherController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreateTeacher([FromBody] CreateTeacherCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpPut]
        public async Task UpdateTeacher([FromBody] UpdateTeacherCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        public async Task DeleteTeacher(Guid id)
        {
            var command = new DeleteTeacherCommand
            {
                Id = id
            };

            await CommandBus.Execute(command);
        }

        [HttpGet]
        public async Task<TeachersResponse> GetAllTeachers()
        {
            var teachersResponse = await QueryBus.Execute<TeachersQuery, TeachersResponse>(new TeachersQuery());

            return teachersResponse;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<TeacherResponse> GetTeacherById(Guid id)
        {
            var teacherResponse = await QueryBus.Execute<TeacherByIdQuery, TeacherResponse>(new TeacherByIdQuery
            {
                Id = id
            });

            return teacherResponse;
        }
    }
}