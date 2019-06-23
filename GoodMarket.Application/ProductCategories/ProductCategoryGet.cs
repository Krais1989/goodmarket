using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCategoryGet : BaseGetQueryHandler<Category>
    {
        public ProductCategoryGet(GoodMarketDbContext db) : base(db) { }
    }
}
