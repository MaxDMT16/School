using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolSystem.Abstractions.Authorization.Services;
using SchoolSystem.Abstractions.CQRS.Buses;

namespace SchoolSystem.WebApi.Controllers.Base
{
    public abstract class SecuredController<TPayload> : SchoolSystemController
        where TPayload : Payload
    {
        protected SecuredController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        public Guid UserId { get; set; }
        public string DeviceId { get; set; }

        protected internal abstract Task<string> GetAccessTokenKey(ActionExecutingContext context, TPayload payload);
        protected internal abstract Task ProcessPayload(ActionExecutingContext context, TPayload payload);
    }
}