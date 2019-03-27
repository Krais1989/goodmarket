using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductCategoryGetAll : BaseGetAllQueryHandler<ProductCategory>
    {
        public ProductCategoryGetAll(GoodMarketDb db) : base(db) { }
    }
}
