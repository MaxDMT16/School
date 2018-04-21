using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SchoolSystem.Abstractions.Configuration;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.WebApi.Logging.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly ILoggerConfiguration _loggerConfiguration;

        public FileLogger(ILoggerConfiguration loggerConfiguration)
        {
            _loggerConfiguration = loggerConfiguration;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (exception != null)
            {
                var jObject = new JObject();

                if (exception is SchoolSystemException schoolSystemException)
                {
                    jObject.Add("Message", schoolSystemException.GetLogObject());
                }
                else
                {
                    jObject.Add("Message", JToken.FromObject(exception));
                }

                var httpContext = state as HttpContext;

                if (httpContext != null)
                {
                    jObject.Add("TraceIdentifier", httpContext.TraceIdentifier);
                    jObject.Add("Method", httpContext.Request.Method);
                }

                jObject.Add("Time", DateTime.UtcNow);


                File.AppendAllText(_loggerConfiguration.Path, jObject.ToString());
            }

            else
            {
                if (formatter != null)
                {
                    File.AppendAllText(_loggerConfiguration.Path, formatter(state, exception));
                }
            }
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}