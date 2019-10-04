using GoodMarket.RabbitMQ;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace GoodMarket.ChatHubs.Consumers
{
    public class UserQueueConsumer : BaseQueueConsumer
    {
        public UserQueueConsumer(IConnection connection, ILogger logger) : base(connection, logger)
        {
        }

        public override string QueueName => "UserQueue";

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey,
            IBasicProperties properties, byte[] body)
        {
            base.HandleBasicDeliver(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body);
        }
    }
}