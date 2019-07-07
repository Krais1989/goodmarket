using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodMarket.RabbitMQ
{
    public interface IBaseQueueProducer
    {
        void Publish<T>(T message);
        void Publish(byte[] message);
    }

    public class BaseQueueProducer : IBaseQueueProducer, IDisposable
    {
        private ILogger<BaseQueueProducer> _logger;
        private IModel _model;

        public virtual string ExchangeName { get; } = "";
        public virtual string RoutingKey { get; } = "";
        public virtual bool Mandatory => false;
        public virtual IBasicProperties BasicProperties => null;

        public BaseQueueProducer(
            ILogger<BaseQueueProducer> logger,
            IConnection conn)
        {
            _logger = logger;
            _model = conn.CreateModel();
        }

        public void Dispose()
        {
            if (_model != null && _model.IsOpen)
                _model.Close();
        }

        public void Publish<T>(T message)
        {
            Publish(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
        }

        public void Publish(byte[] message)
        {
            _model.BasicPublish(ExchangeName, RoutingKey, Mandatory, BasicProperties, message);
        }
    }
}
