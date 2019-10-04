using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Customers;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Customers
{
    public class CustomerCreateCommandHandler : BaseCreateCommandHandler<Customer>
    {
        public CustomerCreateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
