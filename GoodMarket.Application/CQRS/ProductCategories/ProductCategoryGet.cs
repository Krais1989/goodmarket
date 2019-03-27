using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductCategoryGet : BaseGetQueryHandler<ProductCategory>
    {
        public ProductCategoryGet(GoodMarketDb db) : base(db) { }
    }
}
