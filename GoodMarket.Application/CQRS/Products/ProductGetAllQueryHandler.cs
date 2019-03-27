using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    public class ProductGetAllQueryHandler : BaseGetAllQueryHandler<Product>
    {
        public ProductGetAllQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
