using GoodMarket.RabbitMQ;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace GoodMarket.StatisticsProcessor.Consumers
{
    public class OrderStatisticsQueueConsumer : BaseQueueConsumer
    {
        public override string QueueName => "OrderStatisticsQueue";

        public OrderStatisticsQueueConsumer(IConnection connection, ILogger logger) : base(connection, logger)
        {
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey,
            IBasicProperties properties, byte[] body)
        {
            base.HandleBasicDeliver(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body);
            
        }
    }
}