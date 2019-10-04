using System;
using System.Threading.Tasks;
using GoodMarket.Logger;
using GoodMarket.RabbitMQ;
using GoodMarket.StatisticsProcessor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoodMarket.ProcessorsHost
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(hostBuilder =>
                {
                })
                .ConfigureAppConfiguration((context, appBuilder) =>
                {
                    appBuilder.AddJsonFile("appsettings.json");
                    //appBuilder.AddJsonFile("rabbitschema.json");
                })
                .ConfigureGMLogger()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<HostOptions>(opts =>
                    {
                        opts.ShutdownTimeout = TimeSpan.FromSeconds(5);
                    });

                    //services.AddGMRabbit(context.Configuration);
                    services.AddHostedService<StatisticsHostedService>();
                })
                //.UseContentRoot("Content")
                .UseConsoleLifetime()
                .Build();

            await host.RunAsync();
            Console.WriteLine("Completed.");
        }
    }
}