using GoodMarket.RabbitMQ;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace GoodMarket.ChatHubs
{
    public class ChatNotifyMessage
    {
        public string Issuer { get; set; }
        public string Message { get; set; }
    }

    public class ChatNotifyQueueConsumer : BaseQueueConsumer
    {
        public override string QueueName => "ChatNotifyQueue";
        public override bool AutoAck => false;
        public override string ConsumerName => "ChatNotifyConsumer";
        public override bool Exclusive => false;
        public override bool NoLocal => true;
        public override ushort PrefetchCount => 10;

        private readonly IHubContext<MainChatHub, IClientChatHub> _chatHubContext;

        public ChatNotifyQueueConsumer(
            IHubContext<MainChatHub, IClientChatHub> chatHubContext,
            IConnection connection,
            ILogger<ChatNotifyQueueConsumer> logger) : base(connection, logger)
        {
            _chatHubContext = chatHubContext;
        }

        public async override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            base.HandleBasicDeliver(consumerTag, deliveryTag, redelivered, exchange, routingKey, properties, body);
            Model.BasicAck(deliveryTag, true);

            var msgStr = Encoding.UTF8.GetString(body);
            //var msgObj = JsonConvert.DeserializeObject<ChatNotifyMessage>(msgStr);
            await _chatHubContext.Clients.All.SendNotify(msgStr);
        }

    }
}
