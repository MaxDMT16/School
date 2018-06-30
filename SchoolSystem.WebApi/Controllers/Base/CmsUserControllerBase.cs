using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Domain.Authorization.Payloads;
using SchoolSystem.Domain.Authorization.Services;
using SchoolSystem.WebApi.Filters;

namespace SchoolSystem.WebApi.Controllers.Base
{
    [ServiceFilter(typeof(OAuthAuthorizationFilter<CmsUserTokenPayload>))]
    public abstract class CmsUserControllerBase : SecuredController<CmsUserTokenPayload>
    {
        protected CmsUserControllerBase(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        protected internal override async Task<string> GetAccessTokenKey(ActionExecutingContext context, CmsUserTokenPayload payload)
        {
            var refreshTokenByIdQuery = new CmsRefreshTokenByUserIdAndDeviceIdQuery
            {
                Id = payload.UserId,
                DeviceId = payload.DeviceId
            };

            var refreshTokenResponse =
                await QueryBus.Execute<CmsRefreshTokenByUserIdAndDeviceIdQuery, CmsRefreshTokenResponse>(
                    refreshTokenByIdQuery);

            return refreshTokenResponse.RefreshToken;
        }

        protected internal override Task ProcessPayload(ActionExecutingContext context, CmsUserTokenPayload payload)
        {
            UserId = payload.UserId;
            DeviceId = payload.DeviceId;
            return Task.CompletedTask;
        }
    }
}