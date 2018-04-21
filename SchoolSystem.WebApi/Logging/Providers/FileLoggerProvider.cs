using Microsoft.Extensions.Logging;
using SchoolSystem.Abstractions.Configuration;
using SchoolSystem.WebApi.Logging.Loggers;

namespace SchoolSystem.WebApi.Logging.Providers
{
    public class FileLoggerProvider : ILoggerProvider, IFileLoggerProvider
    {
        private readonly ILoggerConfiguration _loggerConfiguration;

        public FileLoggerProvider(ILoggerConfiguration loggerConfiguration)
        {
            _loggerConfiguration = loggerConfiguration;
        }

        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_loggerConfiguration);
        }
    }
}