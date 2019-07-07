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

    public class AccountRegistrationQueueProducer : BaseQueueProducer
    {
        public ExchangeOptions ExchangeOptions;

        public override string ExchangeName => "";
        public override bool Mandatory => true;
        public override string RoutingKey => "";

        public AccountRegistrationQueueProducer(ExchangeOptions options,
                                            ILogger<BaseQueueProducer> logger,
                                            IConnection conn) : base(logger, conn)
        {

        }
    }

    public class BaseQueueProducer : IBaseQueueProducer, IDisposable
    {
        private ILogger<BaseQueueProducer> _logger;
        private IModel _model;
        private IConnection _conn;

        public virtual string ExchangeName { get; } = "";
        public virtual string RoutingKey { get; } = "";
        public virtual bool Mandatory => false;
        public virtual IBasicProperties BasicProperties => null;

        public BaseQueueProducer(
            ILogger<BaseQueueProducer> logger,
            IConnection conn)
        {
            _logger = logger;
            _conn = conn;
            _model = _conn.CreateModel();
        }

        public void Dispose()
        {
            if (_model != null && _model.IsOpen)
                _model.Close();

            if (_conn != null && _conn.IsOpen)
                _conn.Close();
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
