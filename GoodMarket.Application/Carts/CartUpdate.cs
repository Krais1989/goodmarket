using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CartUpdate : BaseUpdateCommandHandler<Cart>
    {
        public CartUpdate(GoodMarketDb db) : base(db) { }
    }
}
