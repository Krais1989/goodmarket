using System.Collections.Generic;

namespace GoodMarket.RabbitMQ
{
    public class ExchangeOptions
    {
        public string Exchange { get; set; }
        public string Type { get; set; }
        public bool Durable { get; set; }
        public bool AutoDelete{ get; set; }
        public IDictionary<string, object> Arguments { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(Exchange) && !string.IsNullOrWhiteSpace(Type);
    }
}
