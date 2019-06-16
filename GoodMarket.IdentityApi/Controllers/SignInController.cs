
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Application.Exceptions;
using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private IMediator _mediator;

        public SignInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Войти по имени/паролю
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(SignInResponse), 200)]
        public async Task<IActionResult> SignIn([FromBody]SignInRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Выйти
        /// </summary>
        [HttpGet("SignOut")]
        [Authorize]
        public IActionResult SignOut()
        {
            return Ok("ok");
        }

        /// <summary>
        /// Текущий юзер
        /// </summary>
        [HttpGet("Current")]
        [Authorize]
        public IActionResult GetCurrent()
        {
            var nameClaim = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Name);
            return Ok(nameClaim.Value);
        }

        /// <summary>
        /// Тестовое исключение
        /// </summary>
        [HttpGet("Exception")]
        public IActionResult Exception()
        {
            throw new AccountNotFoundException("Account not found!");
        }
                    
    }
}