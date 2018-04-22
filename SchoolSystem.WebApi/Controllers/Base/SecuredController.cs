using System;
using SchoolSystem.Abstractions.CQRS.Buses;

namespace SchoolSystem.WebApi.Controllers.Base
{
    public class SecuredController : SchoolSystemController
    {
        public SecuredController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        public Guid UserId { get; set; }
    }
}