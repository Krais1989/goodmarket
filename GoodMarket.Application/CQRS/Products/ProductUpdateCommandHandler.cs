using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductUpdateCommandHandler : BaseUpdateCommandHandler<Product>
    {
        public ProductUpdateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
