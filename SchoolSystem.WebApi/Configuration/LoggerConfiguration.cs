using Microsoft.Extensions.Configuration;
using SchoolSystem.Abstractions.Configuration;

namespace SchoolSystem.WebApi.Configuration
{
    public class LoggerConfiguration : AbstractConfiguration, ILoggerConfiguration
    {
        public LoggerConfiguration(IConfigurationRoot root) : base(root)
        {
        }

        public string LogLevel { get; set; }
        public string Path { get; set; }
    }
}