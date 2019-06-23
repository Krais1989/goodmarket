using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductDeleteCommandHandler : BaseDeleteCommandHandler<Product>
    {
        public ProductDeleteCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
