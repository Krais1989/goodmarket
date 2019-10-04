using System.Threading.Tasks;
using GoodMarket.Domain.Entities.Customers;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.AdminApi.Controllers.REST
{
    [Route("api/[controller]")]
    public class CustomersController : BaseRestController<Customer>
    {
        public CustomersController(GoodMarketDbContext context, IMediator mediator) : base(context, mediator)
        {
        }
        public override Task<ActionResult<Customer>> Get(int id)
        {
            return base.Get(id);
        }
    }
}
