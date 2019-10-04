using System.Collections.Generic;

namespace GoodMarket.RabbitMQ.Options
{
    public class QueueBindOptions
    {
        public string Queue { get; set; }
        public string Exchange { get; set; }
        public string RoutingKey { get; set; }
        public IDictionary<string, object> Arguments { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Queue) && !string.IsNullOrWhiteSpace(Exchange);
    }
}
