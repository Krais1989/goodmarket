using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    public class CustomerGetAllQueryHandler : BaseGetAllQueryHandler<Customer>
    {
        public CustomerGetAllQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
