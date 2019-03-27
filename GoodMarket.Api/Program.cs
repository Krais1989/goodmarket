using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoodMarket.Persistence;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GoodMarket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            host.MigrateDatabase();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureKestrel(opt=> { })
                //.ConfigureLogging((context, logBuilder) => {
                //    logBuilder.ClearProviders();
                //    logBuilder.AddLog4Net();
                //    logBuilder.SetMinimumLevel(LogLevel.Information);
                //})                
                .UseStartup<Startup>();        
    }
}
