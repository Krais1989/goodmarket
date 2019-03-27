using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductCategoryCreate : BaseCreateCommandHandler<ProductCategory>
    {
        public ProductCategoryCreate(GoodMarketDb db) : base(db) { }
    }
}
