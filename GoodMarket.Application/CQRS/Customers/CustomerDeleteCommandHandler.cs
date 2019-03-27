using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class CustomerDeleteCommandHandler : BaseDeleteCommandHandler<Customer>
    {
        public CustomerDeleteCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
