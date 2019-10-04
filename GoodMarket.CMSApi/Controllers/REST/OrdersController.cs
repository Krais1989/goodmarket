using GoodMarket.Domain.Entities.Orders;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.AdminApi.Controllers.REST
{
    [Route("api/[controller]")]
    public class OrdersController : BaseRestController<Order>
    {
        public OrdersController(GoodMarketDbContext context, IMediator mediator) : base(context, mediator)
        {
        }
    }
}
