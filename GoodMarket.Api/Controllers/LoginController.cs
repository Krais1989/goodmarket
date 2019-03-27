using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using GoodMarket.Api.Authorization;
using GoodMarket.Application.Serialization;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GoodMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IMediator _mediator;

        public LoginController(GoodMarketDb db, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Auth([FromBody]AuthorizationRequest request)
        {
            var result = await _mediator.Send(request);
            Response.ContentType = "application/json";
            Response.StatusCode = result.Success ? 200 : 400;
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