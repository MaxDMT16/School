using System;
using System.IO;
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

                jObject.Add("Time", DateTime.UtcNow);

                File.AppendAllText(_loggerConfiguration.Path, jObject.ToString());
            }
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}