using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodMarket.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : BaseRestController<Order>
    {
        public OrdersController(GoodMarketDb context, IMediator mediator) : base(context, mediator)
        {
        }
    }
}
