using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SchoolSystem.Abstractions.Authorization.Services;
using SchoolSystem.Abstractions.Contracts.Queries.CmsUsers;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Exceptions.Authorization;
using SchoolSystem.Domain.Authorization.Services;
using SchoolSystem.WebApi.Attributes;
using SchoolSystem.WebApi.Controllers.Base;

namespace SchoolSystem.WebApi.Filters
{
    public class OAuthAuthorizationFilter<TPayload> : IAsyncActionFilter
        where TPayload : UserTokenPayloadBase
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

            var authAttribute = (context.Controller as SecuredController<TPayload>)?.GetType()
                .GetCustomAttribute<OAuthAttribute>();

            authAttribute = authAttribute ??
                            controllerActionDescriptor?.MethodInfo.GetCustomAttribute<OAuthAttribute>();

            if (authAttribute == null)
            {
                return;
            }

            if (!(context.Controller is SecuredController<TPayload> securedController))
            {
                throw new ControllerTypeMissmatchException(context.Controller.GetType());
            }

            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorization))
            {
                throw new AuthorizationHeaderRequiredException();
            }

            var accessToken = authorization.First();

            var accessTokenService = context.HttpContext.RequestServices.GetRequiredService<IAccessTokenService>();

            var payload = accessTokenService.GetPayload<TPayload>(accessToken);

            var accessTokenKey = await securedController.GetAccessTokenKey(context, payload);

            accessTokenService.ValidateToken<TPayload>(accessToken, accessTokenKey, authAttribute.Scope);

            await securedController.ProcessPayload(context, payload);

            await next.Invoke();
        }
    }
}