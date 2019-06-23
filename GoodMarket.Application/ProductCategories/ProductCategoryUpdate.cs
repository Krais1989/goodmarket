using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCategoryUpdate : BaseUpdateCommandHandler<Category>
    {
        public ProductCategoryUpdate(GoodMarketDbContext db) : base(db) { }
    }
}
