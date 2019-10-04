using System.Collections.Generic;

namespace GoodMarket.Domain.Entities.Products
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
