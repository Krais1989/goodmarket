using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoodMarket.RabbitMQ.Options
{
    public class RabbitSchema
    {
        public string SchemaName { get; set; }
        public IDictionary<string, QueueOptions> Queues { get; set; }
        public IDictionary<string, ExchangeOptions> Exchanges { get; set; }
        public IEnumerable<QueueBindOptions> QueueBinds { get; set; }
        public IEnumerable<ExchangeBindOptions> ExchangeBinds { get; set; }

        public void RemoveInvalids()
        {
            Queues = Queues.Where(e => e.Value.IsValid).ToDictionary(e => e.Key, e => e.Value);
            Exchanges = Exchanges.Where(e => e.Value.IsValid).ToDictionary(e => e.Key, e => e.Value);
            QueueBinds = QueueBinds.Where(e => e.IsValid).ToList();
            ExchangeBinds = ExchangeBinds.Where(e => e.IsValid).ToList();
        }
    }
}
