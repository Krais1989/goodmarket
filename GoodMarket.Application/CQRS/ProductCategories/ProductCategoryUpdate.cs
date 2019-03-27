using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductCategoryUpdate : BaseUpdateCommandHandler<ProductCategory>
    {
        public ProductCategoryUpdate(GoodMarketDb db) : base(db) { }
    }
}
