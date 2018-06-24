using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Abstractions.CQRS.Buses;
using SchoolSystem.Abstractions.Exceptions.Authorization;

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

        protected string GetDeviceId(HttpRequest request)
        {
            if (!request.Headers.TryGetValue("DeviceId", out var allDevices))
            {
                throw new DeviceIdHeaderRequiredException();
            }

            var deviceId = allDevices
                .Aggregate(new StringBuilder(), (builder, s) => builder.Append(s))
                .ToString();

            return deviceId;
        }
    }
}