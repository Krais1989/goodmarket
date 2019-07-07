using GoodMarket.RabbitMQ;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace GoodMarket.QueueProcessor
{
    public class RegistrationQueueConsumer : BaseQueueConsumer
    {
        public override string QueueName => "AccountRegistrationQueue";
        public override bool AutoAck => false;

        public RegistrationQueueConsumer(IConnection connection, ILogger<RegistrationQueueConsumer> logger) : base(connection, logger)
        {
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            base.HandleBasicDeliver(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body);
            Model.BasicAck(deliveryTag, true);
        }
    }
}
