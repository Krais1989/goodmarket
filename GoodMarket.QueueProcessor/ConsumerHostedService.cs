using GoodMarket.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.QueueProcessor
{
    /// <summary>
    /// Обработчик для консумеров
    /// </summary>
    public class ConsumerHostedService : IHostedService
    {
        private IRabbitManager _rabbitMan;
        private IEnumerable<BaseQueueConsumer> _consumers;

        private Timer _timer;
        private readonly ILogger<ConsumerHostedService> _logger;

        protected void LogInformation(string msg) => _logger.LogInformation($"{nameof(ConsumerHostedService)} - {msg}");
        protected void LogWarning(string msg) => _logger.LogWarning($"{nameof(ConsumerHostedService)} - {msg}");
        protected void LogError(string msg) => _logger.LogError($"{nameof(ConsumerHostedService)} - {msg}");
        protected void LogException(Exception e) => _logger.LogError(e, $"{nameof(ConsumerHostedService)}");

        public ConsumerHostedService(
            IRabbitManager rabbitMan,
            IEnumerable<BaseQueueConsumer> consumers,
            ILogger<ConsumerHostedService> logger)
        {
            _rabbitMan = rabbitMan;
            _consumers = consumers;
            _logger = logger;
            _logger.LogInformation($"{nameof(ConsumerHostedService)} - Ctor");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _rabbitMan.EnsureAll();
            foreach (var cons in _consumers)
            {
                cons.StartConsume();
            }

            LogInformation(">>> Start");
            _timer = new Timer(DoWork, this, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void _model_CallbackException(object sender, global::RabbitMQ.Client.Events.CallbackExceptionEventArgs e)
        {
            LogException(e.Exception);
        }

        private void _model_BasicReturn(object sender, global::RabbitMQ.Client.Events.BasicReturnEventArgs e)
        {
            LogWarning($"Mandatory message unrouted exchange: {e.Exchange}, routing: {e.RoutingKey}, info: {e.ReplyCode}-{e.ReplyText}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Dispose();
            LogInformation(">>> Stop");
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            LogInformation(">>> Work start");


            LogInformation(">>> Work end");
        }
    }
}
