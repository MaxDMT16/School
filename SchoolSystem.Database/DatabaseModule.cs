using Autofac;
using SchoolSystem.Database.Context;

namespace SchoolSystem.Database
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SchoolSystemDbContext>().AsImplementedInterfaces();
        }
    }
}