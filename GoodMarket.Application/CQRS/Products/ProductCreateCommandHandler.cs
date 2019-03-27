using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductCreateCommandHandler : BaseCreateCommandHandler<Product>
    {
        public ProductCreateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
