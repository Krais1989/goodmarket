using GoodMarket.RabbitMQ.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoodMarket.RabbitMQ
{
    public static class RabbitMQServiceExtensions
    {
        public static IConfigurationBuilder ConfigureGMRabbitHost(this IConfigurationBuilder builder, string filePostfix = "rabbitschema.json")
        {
            /* Подгрузка файлов с RabbitScheme */
            var schemaFiles = Directory.EnumerateFiles(Environment.CurrentDirectory)
                .Where(e => e.ToLower().EndsWith(filePostfix));
            foreach (var fname in schemaFiles)
            {
                builder.AddJsonFile(fname);
            }

            return builder;
        }

        public static IServiceCollection AddGMRabbitServices(this IServiceCollection service, IConfiguration config)
        {
            var connFactory = new ConnectionFactory(); 
            config.GetSection("RabbitConnection").Bind(connFactory);
            
            // Конфигурация RabbitMQ Connection - одно на всё приложение
            service.AddSingleton(sp => connFactory.CreateConnection(AppDomain.CurrentDomain.FriendlyName));
            service.AddTransient<IBaseQueueProducer, BaseQueueProducer>();
            service.AddTransient<IRabbitManager, RabbitManager>();

            /* Конфигурация загруженных схем в DI */
            var schemaSections = config.GetChildren().Where(e => e.Key.EndsWith("RabbitSchema"));
            foreach (var section in schemaSections)
            {
                service.Configure<RabbitSchema>(section);
            }

            return service;
        }
    }
}