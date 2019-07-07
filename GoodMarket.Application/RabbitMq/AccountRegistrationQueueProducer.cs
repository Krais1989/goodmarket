using GoodMarket.RabbitMQ;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace GoodMarket.Application.RabbitMq
{
    public class AccountRegistrationQueueProducer : BaseQueueProducer
    {
        public override string ExchangeName => "AccountRegistrationExchange";
        public override bool Mandatory => true;
        public override string RoutingKey => "";

        public AccountRegistrationQueueProducer(ILogger<BaseQueueProducer> logger, IConnection conn) : base(logger, conn)
        {
        }
    }
}
