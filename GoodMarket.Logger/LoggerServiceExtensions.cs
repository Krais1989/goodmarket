using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;

namespace GoodMarket.Logger
{
    public static class LoggerServiceExtensions
    {
        public static IWebHostBuilder ConfigureGMLogger(this IWebHostBuilder webHostBuilder, IConfiguration config)
        {
            webHostBuilder.UseSerilog((context, log) =>
            {
                log.ReadFrom.Configuration(config);
            });
            return webHostBuilder;
        }

        public static IHostBuilder ConfigureGMLogger(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration((hostContext, appBuilder) => {
                hostBuilder.UseSerilog((context, log) =>
                {
                    log.ReadFrom.Configuration(hostContext.Configuration);
                });
            });
            
            return hostBuilder;
        }
    }

}
