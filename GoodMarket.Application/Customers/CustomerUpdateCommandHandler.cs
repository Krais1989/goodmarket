using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Customers;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Customers
{
    public class CustomerUpdateCommandHandler : BaseUpdateCommandHandler<Customer>
    {
        public CustomerUpdateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
