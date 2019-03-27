using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class CartGet : BaseGetQueryHandler<Cart>
    {
        public CartGet(GoodMarketDb db) : base(db) { }
    }
}
