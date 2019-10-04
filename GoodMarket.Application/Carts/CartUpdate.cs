using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Carts
{
    public class CartUpdate : BaseUpdateCommandHandler<Cart>
    {
        public CartUpdate(GoodMarketDbContext db) : base(db) { }
    }
}
