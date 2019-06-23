using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductUpdateCommandHandler : BaseUpdateCommandHandler<Product>
    {
        public ProductUpdateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
