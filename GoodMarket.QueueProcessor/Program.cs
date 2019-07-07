using GoodMarket.Logger;
using GoodMarket.RabbitMQ;
using GoodMarket.RabbitMQ.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodMarket.QueueProcessor
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
                    appBuilder.AddJsonFile("rabbitsettings.json");
                })
                .ConfigureGMLogger()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<HostOptions>(opts =>
                    {
                        opts.ShutdownTimeout = TimeSpan.FromSeconds(5);
                    });

                    services.AddGMRabbit(context.Configuration);
                    services.AddHostedService<ConsumerHostedService>();
                    services.AddTransient<BaseQueueConsumer, RegistrationQueueConsumer>();
                })
                .UseContentRoot("Content")
                .UseConsoleLifetime()
                .Build();

            await host.RunAsync();
            Console.WriteLine("Completed.");
        }
    }
}
