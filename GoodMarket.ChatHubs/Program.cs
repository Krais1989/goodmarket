using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoodMarket.Logger;
using GoodMarket.RabbitMQ;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GoodMarket.ChatHubs
{
    public class Program
    {
        static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();
            webHost.Run();

            Console.WriteLine("Completed.");
        }

        static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", false, true);
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", false, true);
                    config.AddJsonFile("rabbitschema.json", false, false);
                    config.AddEnvironmentVariables();
                    config.AddCommandLine(args);
                })
                .UseSerilog((context, serilog) =>
                {
                    serilog.ReadFrom.Configuration(context.Configuration);
                })
                .UseKestrel((context, kestrel) =>
                {
                })
                .UseStartup<Startup>();
    }
}
