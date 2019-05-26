using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class ProductGetQueryHandler : BaseGetQueryHandler<Product>
    {
        public ProductGetQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
