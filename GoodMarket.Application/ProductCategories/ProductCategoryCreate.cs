using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCategoryCreate : BaseCreateCommandHandler<Category>
    {
        public ProductCategoryCreate(GoodMarketDbContext db) : base(db) { }
    }
}
