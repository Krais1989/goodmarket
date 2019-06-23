using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CustomerCreateCommandHandler : BaseCreateCommandHandler<Customer>
    {
        public CustomerCreateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
