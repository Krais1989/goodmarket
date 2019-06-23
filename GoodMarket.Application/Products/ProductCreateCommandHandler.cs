using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCreateCommandHandler : BaseCreateCommandHandler<Product>
    {
        public ProductCreateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
