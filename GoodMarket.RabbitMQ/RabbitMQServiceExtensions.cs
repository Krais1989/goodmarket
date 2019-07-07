using GoodMarket.RabbitMQ.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;

namespace GoodMarket.RabbitMQ
{
    public static class RabbitMQServiceExtensions
    {
        public static IServiceCollection AddGMRabbit(this IServiceCollection service, IConfiguration config)
        {
            var connFactory = new ConnectionFactory();
            config.GetSection("RabbitConnection").Bind(connFactory);
            service.Configure<RabbitOptions>(config.GetSection("RabbitOptions"));
            service.AddSingleton(sp => connFactory.CreateConnection(AppDomain.CurrentDomain.FriendlyName));
            service.AddScoped<IBaseQueueProducer, BaseQueueProducer>();
            service.AddScoped<IRabbitManager, RabbitManager>();
            return service;
        }
    }
}
