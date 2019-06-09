using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace GoodMarket.OrderProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();
            Log.Information("Web host run!");
            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", false, true);
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", false, true);
                    config.AddEnvironmentVariables();
                    config.AddCommandLine(args);
                })
                .UseSerilog((context, serilog) => {
                    serilog.ReadFrom.Configuration(context.Configuration);
                })
                .UseStartup<Startup>();
    }
}
