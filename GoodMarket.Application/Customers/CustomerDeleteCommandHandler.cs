using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Customers;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Customers
{
    public class CustomerDeleteCommandHandler : BaseDeleteCommandHandler<Customer>
    {
        public CustomerDeleteCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
