using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace GoodMarket.Swagger
{
    /// <summary>
    /// https://github.com/domaindrivendev/Swashbuckle.AspNetCore/releases/tag/v5.0.0-rc3
    /// </summary>
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
                opt.SwaggerDoc("v1", new OpenApiInfo() { Title = $"{AppDomain.CurrentDomain.FriendlyName} Api", Version = "v1" });

                opt.AddSecurityDefinition("BearerAuth",
                    new OpenApiSecurityScheme()
                    {
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    });

                opt.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "BearerAuth" }
                            },
                            new string[] { }
                        }
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
        public static IApplicationBuilder UseGMSwagger(this IApplicationBuilder app, string appName)
        {
            app.UseSwagger(opt =>
            {

            });
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", appName);
                // http://localhost:<port>/<route_prefix>/swagger/v1/swagger.json
                //opt.RoutePrefix = "swagger";
            });
            return app;
        }
    }
}
