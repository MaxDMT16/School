using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Authorization.Services;
using SchoolSystem.Abstractions.Contracts.Commands.CmsUsers;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Services.Hashing;
using SchoolSystem.Abstractions.Services.RandomString;
using SchoolSystem.Domain.Authorization.Payloads;
using SchoolSystem.Domain.Authorization.Services;
using SchoolSystem.WebApi.Controllers.Base;
using SchoolSystem.WebApi.Models.Public.Login;

namespace SchoolSystem.WebApi.Controllers.Public.Login
{
    [Produces("application/json")]
    [Route("api/public/cms-login")]
    public class PublicCmsLoginController : SchoolSystemController
    {
        private readonly IMd5HashingService _md5HashingService;
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRandomStringService _randomStringService;

        public PublicCmsLoginController(ICommandBus commandBus, IQueryBus queryBus,
            IMd5HashingService md5HashingService, IAccessTokenService accessTokenService,
            IRandomStringService randomStringService) : base(commandBus, queryBus)
        {
            _md5HashingService = md5HashingService;
            _accessTokenService = accessTokenService;
            _randomStringService = randomStringService;
        }

        [HttpPost]
        public async Task<LoginResponseModel> Login([FromBody] LoginCmsUserRequestModel model)
        {
            var cmsUserIdAndScopeByCredentialsQuery = new CmsUserIdAndScopeByCredentialsQuery
            {
                Login = model.Email,
                Password = _md5HashingService.GetHashBase64(model.Password)
            };

            var cmsUserIdAndScopeResponse =
                await QueryBus.Execute<CmsUserIdAndScopeByCredentialsQuery, CmsUserIdAndScopeResponse>(
                    cmsUserIdAndScopeByCredentialsQuery);

            var refreshToken = _randomStringService.Generate(length: 128);

            var updateCmsUserRefreshTokenCommand = new SetCmsUserRefreshTokenCommand
            {
                Id = cmsUserIdAndScopeResponse.Id,
                RefreshToken = refreshToken,
                DeviceId = GetDeviceId(Request)
            };

            await CommandBus.Execute(updateCmsUserRefreshTokenCommand);

            var accessToken = GenerateAccessToken(cmsUserIdAndScopeResponse, refreshToken);

            return new LoginResponseModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Scope = cmsUserIdAndScopeResponse.Scope
            };
        }


        private string GenerateAccessToken(CmsUserIdAndScopeResponse response, string refreshToken)
        {
            var cmsTokenPayload = new CmsUserTokenPayload
            {
                UserId = response.Id,
                DeviceId = GetDeviceId(Request)
            };

            var accessToken = _accessTokenService.CreateToken(cmsTokenPayload, refreshToken, response.Scope);

            return accessToken;
        }
    }
}