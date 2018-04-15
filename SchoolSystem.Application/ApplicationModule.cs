using Autofac;
using SchoolSystem.Application.Buses;

namespace SchoolSystem.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().AsImplementedInterfaces();
            builder.RegisterType<QueryBus>().AsImplementedInterfaces();
        }
    }
}