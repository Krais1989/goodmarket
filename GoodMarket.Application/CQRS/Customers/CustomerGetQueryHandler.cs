using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GoodMarket.Application.CQRS
{
    public class CustomerGetQueryHandler : BaseGetQueryHandler<Customer>
    {
        public CustomerGetQueryHandler(GoodMarketDb db) : base(db) { }
        public override async Task<Customer> Handle(BaseGetQuery<Customer> request, CancellationToken cancellationToken)
        {
            return await _set
                .Where(e=>e.Id == request.Id)
                .Include(e => e.Cart)
                .SingleAsync(cancellationToken);
        }
    }
}
