using System.Collections.Generic;

namespace GoodMarket.Domain.Entities.Products
{
    /// <summary>
    /// Категория продукта
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        /// <summary>
        /// Родительская категория. 0 - нет
        /// </summary>
        public int ParentId { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Родительская категория
        /// </summary>
        public Category Parent { get; set; }

        /// <summary>
        /// Дочерние категории
        /// </summary>
        public ICollection<Category> Childs { get; set; }


        /// <summary>
        /// Продукты в категории
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}
