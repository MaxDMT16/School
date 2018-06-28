using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.Contracts.Queries.User;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Domain.Authorization.Payloads;
using SchoolSystem.WebApi.Filters;

namespace SchoolSystem.WebApi.Controllers.Base
{
    [ServiceFilter(typeof(OAuthAuthorizationFilter<UserTokenPayload>))]
    public abstract class UserControllerBase : SecuredController<UserTokenPayload>
    {
        protected UserControllerBase(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        protected internal override async Task<string> GetAccessTokenKey(ActionExecutingContext context, UserTokenPayload payload)
        {
            var refreshTokenByIdQuery = new UserRefreshTokenByUserIdAndDeviceIdQuery
            {
                Id = payload.UserId,
                DeviceId = payload.DeviceId
            };

            var refreshTokenResponse =
                await QueryBus.Execute<UserRefreshTokenByUserIdAndDeviceIdQuery, UserRefreshTokenResponse>(
                    refreshTokenByIdQuery);

            return refreshTokenResponse.RefreshToken;
        }

        protected internal override Task ProcessPayload(ActionExecutingContext context, UserTokenPayload payload)
        {
            UserId = payload.UserId;
            DeviceId = payload.DeviceId;
            return Task.CompletedTask;
        }
    }
}