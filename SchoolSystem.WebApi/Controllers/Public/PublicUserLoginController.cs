using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.Authorization.Services;
using SchoolSystem.Abstractions.Contracts.Commands.User;
using SchoolSystem.Abstractions.Contracts.Queries.User;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Services.Hashing;
using SchoolSystem.Abstractions.Services.RandomString;
using SchoolSystem.Domain.Authorization.Payloads;
using SchoolSystem.WebApi.Controllers.Base;
using SchoolSystem.WebApi.Models.Login;

namespace SchoolSystem.WebApi.Controllers.Public
{
    public class PublicUserLoginController : SchoolSystemController
    {
        private readonly IMd5HashingService _md5HashingService;
        private readonly IAccessTokenService _accessTokenService;
        private readonly IRandomStringService _randomStringService;

        public PublicUserLoginController(ICommandBus commandBus, IQueryBus queryBus,
            IMd5HashingService md5HashingService, IAccessTokenService accessTokenService,
            IRandomStringService randomStringService) : base(commandBus, queryBus)
        {
            _md5HashingService = md5HashingService;
            _accessTokenService = accessTokenService;
            _randomStringService = randomStringService;
        }

        [HttpPost]
        public async Task<LoginResponseModel> Login([FromBody] LoginRequestModel model)
        {
            var cmsUserIdAndScopeByCredentialsQuery = new UserIdAndScopeByCredentialsQuery
            {
                Login = model.Login,
                Password = _md5HashingService.GetHashBase64(model.Password)
            };

            var userIdAndScopeResponse =
                await QueryBus.Execute<UserIdAndScopeByCredentialsQuery, UserIdAndScopeResponse>(
                    cmsUserIdAndScopeByCredentialsQuery);

            var refreshToken = _randomStringService.Generate(length: 128);

            var updateCmsUserRefreshTokenCommand = new SetUserRefreshTokenCommand
            {
                Id = userIdAndScopeResponse.Id,
                RefreshToken = refreshToken,
                DeviceId = GetDeviceId(Request)
            };

            await CommandBus.Execute(updateCmsUserRefreshTokenCommand);

            var accessToken = GenerateAccessToken(userIdAndScopeResponse, refreshToken);

            return new LoginResponseModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Scope = userIdAndScopeResponse.Scope
            };
        }


        private string GenerateAccessToken(UserIdAndScopeResponse response, string refreshToken)
        {
            var tokenPayload = new UserTokenPayload
            {
                UserId = response.Id,
                DeviceId = GetDeviceId(Request)
            };

            var accessToken = _accessTokenService.CreateToken(tokenPayload, refreshToken, response.Scope);

            return accessToken;
        }
    }
}