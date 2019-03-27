using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class CartDelete : BaseDeleteCommandHandler<Cart>
    {
        public CartDelete(GoodMarketDb db) : base(db) { }
    }
}
