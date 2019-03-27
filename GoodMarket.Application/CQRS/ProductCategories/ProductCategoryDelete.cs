using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductCategoryDelete : BaseDeleteCommandHandler<ProductCategory>
    {
        public ProductCategoryDelete(GoodMarketDb db) : base(db) { }
    }
}
