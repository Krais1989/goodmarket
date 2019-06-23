using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CartCreate : BaseCreateCommandHandler<Cart>
    {
        public CartCreate(GoodMarketDbContext db) : base(db) { }
    }
}
