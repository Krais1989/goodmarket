using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Customers;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Customers
{
    public class CustomerGetAllQueryHandler : BaseGetAllQueryHandler<Customer>
    {
        public CustomerGetAllQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
