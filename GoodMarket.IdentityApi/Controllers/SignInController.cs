
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Application.Exceptions;
using GoodMarket.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodMarket.IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private IMediator _mediator;
        private readonly GMUserManager _userMan;

        public SignInController(IMediator mediator, GMUserManager userMan)
        {
            _mediator = mediator;
            _userMan = userMan;
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
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> GetCurrent()
        {
            var nameClaim = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Name);
            var user = await _userMan.FindByNameAsync(nameClaim.Value);
            return Ok(user);
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