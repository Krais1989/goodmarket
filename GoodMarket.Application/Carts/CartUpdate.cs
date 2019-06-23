using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CartUpdate : BaseUpdateCommandHandler<Cart>
    {
        public CartUpdate(GoodMarketDbContext db) : base(db) { }
    }
}
