using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CustomerUpdateCommandHandler : BaseUpdateCommandHandler<Customer>
    {
        public CustomerUpdateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
