using GoodMarket.OrderProcessor.Controllers;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodMarket.OrderProcessor
{
    public class OrderMessageReceiver : DefaultBasicConsumer
    {
        private readonly ILogger<OrderProcessController> _logger;
        public OrderMessageReceiver(ILogger<OrderProcessController> logger, IModel model) : base(model)
        {
            _logger = logger;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            //base.HandleBasicDeliver(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body);
            _logger.LogWarning($"consumerTag: {consumerTag}\n" +
                $"deliveryTag: {deliveryTag}\n" +
                $"redelivered: {redelivered}\n" +
                $"exchange: {exchange}\n" +
                $"routingKey: {routingKey}\n" +
                $"body:{Encoding.UTF8.GetString(body)}");

        }
    }
}
