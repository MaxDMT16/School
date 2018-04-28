using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SchoolSystem.Abstractions.Configuration;
using SchoolSystem.Application;
using SchoolSystem.Database;
using SchoolSystem.Database.Context;
using SchoolSystem.Domain;
using SchoolSystem.WebApi.Configuration;
using SchoolSystem.WebApi.Logging;
using SchoolSystem.WebApi.Logging.Providers;
using SchoolSystem.WebApi.Middleware;
using SchoolSystem.WebApi.OperationFilters;
using Swashbuckle.AspNetCore.Swagger;

namespace SchoolSystem.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolSystemDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SchoolSystem")));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "SchoolSystem API", Version = "v1"});
                c.CustomSchemaIds(x => x.FullName);
                c.DescribeAllEnumsAsStrings();
                c.OperationFilter<AuthorizationOperationFilter>();
            });

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ApplicationModule>();
            containerBuilder.RegisterModule<DatabaseModule>();
            containerBuilder.RegisterModule<DomainModule>();
            containerBuilder.RegisterModule<ConfigurationModule>();
            containerBuilder.RegisterModule<LoggingModule>();

            containerBuilder.Populate(services);
            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfigurationRoot root,
            ILoggerFactory loggerFactory)
        {
            var loggerConfiguration = app.ApplicationServices.GetRequiredService<ILoggerConfiguration>();
            loggerFactory.AddProvider(new FileLoggerProvider(loggerConfiguration));

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolSystem API V1"); });

            app.UseMvc();
        }
    }
}