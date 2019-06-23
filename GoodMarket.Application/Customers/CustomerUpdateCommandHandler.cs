using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CustomerUpdateCommandHandler : BaseUpdateCommandHandler<Customer>
    {
        public CustomerUpdateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
