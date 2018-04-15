using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.CQRS.Buses;

namespace SchoolSystem.WebApi.Controllers.Base
{
    [Produces("application/json")]
    [Route("api/SchoolSystem")]
    public class SchoolSystemController : Controller
    {
        protected readonly ICommandBus CommandBus;
        protected readonly IQueryBus QueryBus;

        public SchoolSystemController(ICommandBus commandBus, IQueryBus queryBus)
        {
            CommandBus = commandBus;
            QueryBus = queryBus;
        }
    }
}