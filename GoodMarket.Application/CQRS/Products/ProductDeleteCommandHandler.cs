using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductDeleteCommandHandler : BaseDeleteCommandHandler<Product>
    {
        public ProductDeleteCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
