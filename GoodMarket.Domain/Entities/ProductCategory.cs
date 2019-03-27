using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Domain
{
    public class ProductCategory : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
