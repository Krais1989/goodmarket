using System.Collections.Generic;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Аттрибут продукта
    /// </summary>
    public class Attribute
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Title { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
