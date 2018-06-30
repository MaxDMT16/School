using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.Teachers;
using SchoolSystem.Abstractions.Contracts.Queries.Teachers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Services.Hashing;
using SchoolSystem.WebApi.Controllers.Base;
using SchoolSystem.WebApi.Models.Registrations;

namespace SchoolSystem.WebApi.Controllers.Public.Registration
{
    [Route("api/public/registration/teacher")]
    public class PublicTeacherRegistrationController : SchoolSystemController
    {
        private readonly IMd5HashingService _md5HashingService;

        public PublicTeacherRegistrationController(ICommandBus commandBus, IQueryBus queryBus,
            IMd5HashingService md5HashingService) : base(commandBus, queryBus)
        {
            _md5HashingService = md5HashingService;
        }

        [HttpGet]
        [Route("{registrationCode}")]
        public async Task<TeacherByRegistrationCodeResponse> GetInfoByRegistrationCode(Guid registrationCode)
        {
            var teacherResponse = await QueryBus.Execute<TeacherByRegistrationCodeQuery, TeacherByRegistrationCodeResponse>(
                new TeacherByRegistrationCodeQuery
                {
                    RegistrationCode = registrationCode
                });

            return teacherResponse;
        }

        [HttpPost]
        public async Task RegisterTeacher(RegistrationModel model)
        {
            await CommandBus.Execute(new UpdateTeacherByRegistrationCodeCommand
            {
                RegistrationCode = model.RegistrationCode,
                Email = model.Email,
                Password = _md5HashingService.GetHashBase64(model.Password)
            });
        }
    }
}