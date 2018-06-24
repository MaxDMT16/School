using System.Collections.Generic;
using System.Linq;
using SchoolSystem.WebApi.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SchoolSystem.WebApi.OperationFilters
{
    public class RequireDeviceIdOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            (operation.Parameters ?? (operation.Parameters = new List<IParameter>())).Add(new NonBodyParameter
            {
                Name = "DeviceId",
                In = "header",
                Description = "DeviceId",
                Required = true,
                Type = "string",
                Default = "swagger"
            });
        }
    }
}