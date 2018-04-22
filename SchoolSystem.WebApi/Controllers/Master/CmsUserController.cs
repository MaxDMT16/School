using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Contracts.Commands.CmsUsers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Abstractions.Services.Hashing;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Controllers.Master
{
    [Produces("application/json")]
    [Route("api/master/cms-user")]
    [OAuth(ScopeFlag.Master)]
    public class CmsUserController : SchoolSystemController
    {
        private readonly IMd5HashingService _md5HashingService;

        public CmsUserController(ICommandBus commandBus, IQueryBus queryBus, IMd5HashingService md5HashingService) :
            base(commandBus, queryBus)
        {
            _md5HashingService = md5HashingService;
        }

        [HttpPost]
        public async Task CreateCmsUser(CreateCmsUserCommand command)
        {
            command.Password = _md5HashingService.GetHashBase64(command.Password);

            await CommandBus.Execute(command);
        }

        [HttpPatch]
        public async Task UpdateCmsUserScope(UpdateCmsUserScopeCommand command)
        {
            await CommandBus.Execute(command);
        }

        [HttpDelete]
        public async Task DeleteCmsUser(DeleteCmsUserCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}