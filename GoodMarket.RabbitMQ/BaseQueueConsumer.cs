using GoodMarket.RabbitMQ.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace GoodMarket.RabbitMQ
{
    /// <summary>
    /// Базовый консумер
    /// </summary>
    public abstract class BaseQueueConsumer : IBasicConsumer, IDisposable
    {
        protected readonly ILogger _logger;
        protected string _consumerName;
        private IConnection _connection { get; }

        public IModel Model { get; }
        public event EventHandler<ConsumerEventArgs> ConsumerCancelled;

        public virtual string ConsumerName
        {
            get
            {
                if (string.IsNullOrEmpty(_consumerName))
                    _consumerName = GetType().Name;
                return _consumerName;
            }
        }

        public abstract string QueueName { get; }
        public virtual ushort PrefetchCount => 5;
        public virtual bool AutoAck => true;
        public virtual bool NoLocal => false;
        public virtual bool Exclusive => false;

        public virtual void LogInformation(string msg) => _logger.LogInformation($"{ConsumerName} - {msg}");
        public virtual void LogWarning(string msg) => _logger.LogWarning($"{ConsumerName} - {msg}");
        public virtual void LogError(string msg) => _logger.LogError($"{ConsumerName} - {msg}");

        public BaseQueueConsumer(
            IConnection connection,
            ILogger logger)
        {
            _connection = connection;
            _logger = logger;

            Model = _connection.CreateModel();
        }

        public virtual void StartConsume()
        {
            Model.BasicQos(0, PrefetchCount, false);
            Model.BasicConsume(this, QueueName, AutoAck, ConsumerName, NoLocal, Exclusive);
        }

        public virtual void HandleBasicCancel(string consumerTag)
        {
            LogInformation($"Cancel: {consumerTag}");
            Model.BasicCancel(consumerTag);
        }

        public virtual void HandleBasicCancelOk(string consumerTag)
        {
            LogInformation($"Cancel Ok: {consumerTag}");
        }

        public virtual void HandleBasicConsumeOk(string consumerTag)
        {
            LogInformation($"Consume OK: {consumerTag}");
        }

        public virtual void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            var msgStr = Encoding.UTF8.GetString(body);
            var result = new StringBuilder();
            result.Append($"[Deliver]")
                .Append($" consumer_tag: {consumerTag}")
                .Append($" delivery_tag: {deliveryTag}")
                .Append($" redelivered: {redelivered}")
                .Append($" exchange: {exchange}")
                .Append($" routingKey: {routingKey}")
                .Append($"\nbody: {msgStr}");
            LogInformation(result.ToString());
        }

        public virtual void HandleModelShutdown(object model, ShutdownEventArgs reason)
        {
            LogInformation($"ModelShutdown: {model} {reason.ReplyCode}-{reason.ReplyText}");
        }

        public void Dispose()
        {
            if (Model != null && Model.IsOpen)
                Model.Close();
        }
    }
}
