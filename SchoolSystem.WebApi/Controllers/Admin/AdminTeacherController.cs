using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.Teachers;
using SchoolSystem.Abstractions.Contracts.Queries.Teachers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;
using SchoolSystem.WebApi.Models.Admin.Teacher;

namespace SchoolSystem.WebApi.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/teacher")]
    [OAuth(Scope.Admin)]
    public class AdminTeacherController : CmsUserControllerBase
    {
        public AdminTeacherController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task<CreateTeacherResponseModel> CreateTeacher([FromBody] CreateTeacherRequestModel model)
        {
            var registrationCode = Guid.NewGuid();

            var command = new CreateTeacherCommand
            {
                RegistrationCode = registrationCode,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await CommandBus.Execute(command);

            return new CreateTeacherResponseModel
            {
                RegistrationCode = registrationCode
            };
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