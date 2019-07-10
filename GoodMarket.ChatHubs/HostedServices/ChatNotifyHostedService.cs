using GoodMarket.RabbitMQ;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.ChatHubs
{
    /// <summary>
    /// Чтение сообщений с очереди 
    /// </summary>
    public class ChatNotifyHostedService : IHostedService
    {
        private IRabbitManager _rabbitMan;
        private IEnumerable<BaseQueueConsumer> _consumers;

        public ChatNotifyHostedService(
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
