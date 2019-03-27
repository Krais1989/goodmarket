using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class CartCreate : BaseCreateCommandHandler<Cart>
    {
        public CartCreate(GoodMarketDb db) : base(db) { }
    }
}
