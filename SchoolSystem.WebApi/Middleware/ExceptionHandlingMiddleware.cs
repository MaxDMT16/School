using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<Log4NetLogger>();
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleException(httpContext, exception);
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception exception)
        {
            var responseObject = new JObject
            {
                ["TraceIdentifier"] = httpContext.TraceIdentifier
            };

            try
            {
                var statusCode = HttpStatusCode.InternalServerError;

                if (exception is SchoolSystemException schoolSystemException)
                {
                    var statusCodeAttribute = schoolSystemException.GetType().GetCustomAttribute<StatusCodeAttribute>();

                    statusCode = statusCodeAttribute.StatusCode;

                    responseObject.Merge(schoolSystemException.GetResponseObject(), new JsonMergeSettings
                    {
                        MergeArrayHandling = MergeArrayHandling.Union,
                        MergeNullValueHandling = MergeNullValueHandling.Merge
                    });
                }
                else
                {
                    responseObject["Message"] = "Something went wrong, contact us with RequestId";
                }

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int) statusCode;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, 1, httpContext, exception,
                    (context, exception1) => "Error while handling exception");
            }

            _logger.Log(LogLevel.Error, 1, httpContext, exception, (context, exception1) => responseObject.ToString());
            await httpContext.Response.WriteAsync(responseObject.ToString());
        }
    }
}