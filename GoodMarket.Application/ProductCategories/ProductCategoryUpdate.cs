using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCategoryUpdate : BaseUpdateCommandHandler<Category>
    {
        public ProductCategoryUpdate(GoodMarketDb db) : base(db) { }
    }
}
