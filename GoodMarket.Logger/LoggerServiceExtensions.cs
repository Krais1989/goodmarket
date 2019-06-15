using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GoodMarket.Logger
{
    public static class LoggerServiceExtensions
    {
        public static IWebHostBuilder ConfigureGMLogger(this IWebHostBuilder webHostBuilder, IConfiguration config)
        {
            return webHostBuilder;
        }

        public static IServiceCollection AddGMLogger(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
