using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductCreateCommandHandler : BaseCreateCommandHandler<Product>
    {
        public ProductCreateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
