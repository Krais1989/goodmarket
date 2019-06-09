using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodMarket.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoodMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private Mediator _mediator;
        private ILogger _logger;

        public CartController(Mediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<IActionResult> SetQuantity([FromBody]CartRecordQuantityMessage request)
        {
            var result = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRecord([FromBody]CartRecordRemoveMessage request)
        {
            var result = await _mediator.Send(request);
            return Ok();
        }
    }
}