using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CustomerDeleteCommandHandler : BaseDeleteCommandHandler<Customer>
    {
        public CustomerDeleteCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
