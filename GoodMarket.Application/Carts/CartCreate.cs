using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Carts
{
    public class CartCreate : BaseCreateCommandHandler<Cart>
    {
        public CartCreate(GoodMarketDbContext db) : base(db) { }
    }
}
