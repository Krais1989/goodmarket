using System.Collections.Generic;

namespace GoodMarket.RabbitMQ.Options
{
    public class ExchangeBindOptions
    {
        public string Destination { get; set; }
        public string Source { get; set; }
        public string RoutingKey { get; set; }
        public IDictionary<string, object> Arguments { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Destination) && !string.IsNullOrWhiteSpace(Source);
    }
}
