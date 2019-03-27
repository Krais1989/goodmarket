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
    public class CustomersController : BaseRestController<Customer>
    {
        public CustomersController(GoodMarketDb context, IMediator mediator) : base(context, mediator)
        {
        }
        public override Task<ActionResult<Customer>> Get(int id)
        {
            return base.Get(id);
        }
    }
}
