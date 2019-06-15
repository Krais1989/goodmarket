using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Authentication
{
    public static class AuthenticationServiceExtensions
    {
        public static IServiceCollection AddGMAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
            var token = config.GetSection("JwtSettings").Get<JwtSettings>();

            /* Валидация токена */
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt => {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = token.GetSymmetricSecurityKey(), // Симметричный ключ проверки токена

                    ValidateAudience = false,
                    ValidAudience = token.Audience,

                    ValidateIssuer = false,
                    ValidIssuer = token.Issuer,

                    ValidateLifetime = true,
                };
            });

            services.AddScoped<IJwtFactory, JwtFactory>();
            return services;
        }
    }
}
