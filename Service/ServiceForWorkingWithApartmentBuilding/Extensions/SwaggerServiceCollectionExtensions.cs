using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;

namespace ServiceForWorkingWithApartmentBuilding.Extensions
{
    internal static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Service For Working With Apartment Building"
                });

                options.CustomSchemaIds(type => type.FullName);

                options.MapType<Guid>(() => new OpenApiSchema { Type = "string", Format = "uuid", Default = new OpenApiString(Guid.NewGuid().ToString()) });

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                //options.IncludeXmlComments(Path.Combine(basePath, "ServiceForWorkingWithApartmentBuilding.xml"));
            });
        }
    }
}

