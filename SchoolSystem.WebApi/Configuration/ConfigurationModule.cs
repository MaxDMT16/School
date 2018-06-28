using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace SchoolSystem.WebApi.Configuration
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateConfigurationRoot)
                .SingleInstance()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AssignableTo<AbstractConfiguration>()
                .AsImplementedInterfaces()
                .SingleInstance()
                .AutoActivate();
        }

        private IConfigurationRoot CreateConfigurationRoot(IComponentContext context)
        {
            var builder = new ConfigurationBuilder();

            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            var removeIndex = basePath.IndexOf("\\bin");

            basePath = basePath.Substring(0, removeIndex);

            var configurationBuilder = builder.SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configurationRoot = configurationBuilder.Build();

            return configurationRoot;
        }
    }
}