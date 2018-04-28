using System.Collections.Generic;
using System.Linq;
using SchoolSystem.WebApi.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SchoolSystem.WebApi.OperationFilters
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (!context.ApiDescription.ControllerAttributes().OfType<OAuthAttribute>().Any())
            {
                return;
            }

            (operation.Parameters ?? (operation.Parameters = new List<IParameter>())).Add(new NonBodyParameter
            {
                Name = "Authorization",
                In = "header",
                Description = "Access token",
                Required = true,
                Type = "string"
            });
        }
    }
}