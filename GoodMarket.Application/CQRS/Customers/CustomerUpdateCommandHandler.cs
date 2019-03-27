using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class CustomerUpdateCommandHandler : BaseUpdateCommandHandler<Customer>
    {
        public CustomerUpdateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
