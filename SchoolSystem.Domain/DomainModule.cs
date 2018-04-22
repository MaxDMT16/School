using Autofac;
using FluentValidation;
using SchoolSystem.Abstractions.CQRS.Handlers;
using SchoolSystem.Domain.Authorization.Services;
using SchoolSystem.Domain.Services.Hashing;
using SchoolSystem.Domain.Services.RandomString;

namespace SchoolSystem.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IValidator<>))
                .AsImplementedInterfaces();

            builder.RegisterType<Md5HashingService>().AsImplementedInterfaces();

            builder.RegisterType<AccessTokenService>().AsImplementedInterfaces();

            builder.RegisterType<RandomStringService>().AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(InlineValidator<>)).As(typeof(IValidator<>));
        }
    }
}