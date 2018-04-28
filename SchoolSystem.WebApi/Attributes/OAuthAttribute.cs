using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Abstractions.Authorization.Services;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Abstractions.Exceptions.Authorization;
using SchoolSystem.Domain.Authorization.Services;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class OAuthAttribute : ActionFilterAttribute
    {
        private readonly ScopeFlag Scope;

        public OAuthAttribute(ScopeFlag scope)
        {
            Scope = scope;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorization))
            {
                throw new AuthorizationHeaderRequiredException();
            }

            var accessToken = authorization.First();

            var accessTokenService = context.HttpContext.RequestServices.GetRequiredService<IAccessTokenService>();

            var payload = accessTokenService.GetPayload<CmsTokenPayload>(accessToken);

            var accessTokenKey = await GetAccessTokenKey(context, payload);

            accessTokenService.ValidateToken<CmsTokenPayload>(accessToken, accessTokenKey, Scope);

            if (context.Controller is SecuredController securedController)
            {
                securedController.UserId = payload.UserId;
            }

            await next.Invoke();
        }

        private async Task<string> GetAccessTokenKey(ActionExecutingContext context, CmsTokenPayload payload)
        {
            var queryBus = context.HttpContext.RequestServices.GetRequiredService<IQueryBus>();

            var refreshTokenByIdQuery = new RefreshTokenByIdQuery
            {
                Id = payload.UserId
            };

            var refreshTokenResponse =
                await queryBus.Execute<RefreshTokenByIdQuery, RefreshTokenResponse>(refreshTokenByIdQuery);

            return refreshTokenResponse.RefreshToken;
        }
    }
}