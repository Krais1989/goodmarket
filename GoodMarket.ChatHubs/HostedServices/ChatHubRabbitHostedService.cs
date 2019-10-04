using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GoodMarket.RabbitMQ;
using Microsoft.Extensions.Hosting;

namespace GoodMarket.ChatHubs.HostedServices
{
    /// <summary>
    /// Сервис работы с очередями ChatHub
    /// </summary>
    public class ChatHubRabbitHostedService : IHostedService
    {
        private IRabbitManager _rabbitMan;
        private IEnumerable<BaseQueueConsumer> _consumers;

        public ChatHubRabbitHostedService(
            IEnumerable<BaseQueueConsumer> consumers,
            IRabbitManager rabbitMan)
        {
            _rabbitMan = rabbitMan;
            _consumers = consumers;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _rabbitMan.EnsureAll();
            foreach (var cons in _consumers)
                cons.StartConsume();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
