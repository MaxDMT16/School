using Autofac;
using SchoolSystem.WebApi.Logging.Loggers;

namespace SchoolSystem.WebApi.Logging
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileLogger>()
                .SingleInstance()
                .AsImplementedInterfaces();
        }
    }
}