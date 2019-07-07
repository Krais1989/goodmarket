using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GoodMarket.Swagger
{
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// Конфигурация Swagger 
        /// </summary>
        public static IServiceCollection AddGMSwagger(this IServiceCollection services, IConfiguration config = null)
        {
            /* Swagger */
            services.AddSwaggerGen((opt) =>
            {
                /* Swagger-документы */
                opt.SwaggerDoc("v1",
                    new Info()
                    {
                        Title = $"{AppDomain.CurrentDomain.FriendlyName} Api",
                        Version = "v1",
                    });

                //options.CustomSchemaIds(x => x.FullName);

                /* Возможность указания Bearer-токена */
                opt.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                opt.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });

                /* Использовать XML-документ с метаданными методов и классов */
                //var xmlFile = $"{AppDomain.CurrentDomain.BaseDirectory}{AppDomain.CurrentDomain.FriendlyName}.xml";
                var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{AppDomain.CurrentDomain.FriendlyName}.xml");
                opt.IncludeXmlComments(xmlPath);

                /* Генерация xml-документа проекта, *.csproj:
                 <PropertyGroup>
                  <GenerateDocumentationFile>true</GenerateDocumentationFile>
                  <NoWarn>$(NoWarn);1591</NoWarn>
                </PropertyGroup>
                 */
            });

            return services;
        }

        /// <summary>
        /// Подключение Swagger и Swagger UI в обработку
        /// </summary>
        public static IApplicationBuilder UseGMSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "GoodMarket API v1");
                // http://localhost:<port>/<route_prefix>/swagger/v1/swagger.json
                //opt.RoutePrefix = "swagger";
            });
            return app;
        }
    }
}
