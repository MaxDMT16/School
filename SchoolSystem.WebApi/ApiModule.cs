using Autofac;
using SchoolSystem.WebApi.Filters;

namespace SchoolSystem.WebApi
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(OAuthAuthorizationFilter<>)).AsSelf();
        }
    }
}