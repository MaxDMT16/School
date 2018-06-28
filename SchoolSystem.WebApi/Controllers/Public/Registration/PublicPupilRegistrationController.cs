using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.Pupils;
using SchoolSystem.Abstractions.Contracts.Queries.Pupils;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Services.Hashing;
using SchoolSystem.WebApi.Controllers.Base;
using SchoolSystem.WebApi.Models.Registrations;

namespace SchoolSystem.WebApi.Controllers.Public.Registration
{
    [Route("api/public/registration/pupil")]
    public class PublicPupilRegistrationController : SchoolSystemController
    {
        private readonly IMd5HashingService _md5HashingService;

        public PublicPupilRegistrationController(ICommandBus commandBus, IQueryBus queryBus,
            IMd5HashingService md5HashingService) : base(commandBus, queryBus)
        {
            _md5HashingService = md5HashingService;
        }

        [HttpGet]
        [Route("{registrationCode}")]
        public async Task<PupilByRegistrationCodeResponse> GetInfoByRegistrationCode(Guid registrationCode)
        {
            var pupilResponse = await QueryBus.Execute<PupilByRegistrationCodeQuery, PupilByRegistrationCodeResponse>(
                new PupilByRegistrationCodeQuery
                {
                    RegistrationCode = registrationCode
                });

            return pupilResponse;
        }

        [HttpPost]
        public async Task RegisterPupil(RegistrationModel model)
        {
            await CommandBus.Execute(new UpdatePupilCredentialsByRegistrationCodeCommand
            {
                RegistrationCode = model.RegistrationCode,
                Email = model.Email,
                Password = _md5HashingService.GetHashBase64(model.Password)
            });
        }
    }
}