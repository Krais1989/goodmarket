using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCategoryGetAll : BaseGetAllQueryHandler<Category>
    {
        public ProductCategoryGetAll(GoodMarketDb db) : base(db) { }
    }
}
