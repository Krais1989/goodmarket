using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCategoryCreate : BaseCreateCommandHandler<Category>
    {
        public ProductCategoryCreate(GoodMarketDb db) : base(db) { }
    }
}
