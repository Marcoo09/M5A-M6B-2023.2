using System.ComponentModel;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerOperationDescriptionFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.TryGetMethodInfo(out var methodInfo))
        {
            // Check if the method has the [Description] attribute
            var descriptionAttribute = methodInfo.GetCustomAttribute<DescriptionAttribute>();

            if (descriptionAttribute != null)
            {
                // Set the description from the [Description] attribute
                operation.Summary = descriptionAttribute.Description;
            }
        }
    }
}
