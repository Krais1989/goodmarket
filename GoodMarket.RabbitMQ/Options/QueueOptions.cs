using RabbitMQ.Client;
using System.Collections.Generic;

namespace GoodMarket.RabbitMQ
{
    public class QueueOptions
    {
        public string Queue { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public IDictionary<string, object> Arguments { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Queue);
    }
}
