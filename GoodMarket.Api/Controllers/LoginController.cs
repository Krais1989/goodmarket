
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Application.Serialization;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : ControllerBase
    {
        private IMediator _mediator;

        public SignController(GoodMarketDb db, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Auth([FromBody]SignInRequest request)
        {
            var result = await _mediator.Send(request);
            Response.ContentType = "application/json";
            await Response.WriteAsync(SSerializer.Serialize(result));
        }

        [HttpGet("logoff")]
        public IActionResult Logoff()
        {
            return Ok("ok");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCurrent()
        {
            return Ok("Authorized");
        }
    }
}