using System;
using System.Collections.Generic;

namespace GoodMarket.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

        public int GroupId { get; set; }
    }
}
