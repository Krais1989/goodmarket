namespace GoodMarket.Domain
{
    /// <summary>
    /// Связь продукт-аттрибут
    /// </summary>
    public class ProductAttribute
    {
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        /// <summary>
        /// Значение аттрибута
        /// </summary>
        public string Value { get; set; }
        public Product Product { get; set; }
        public Attribute Attribute { get; set; }
        
    }
}
