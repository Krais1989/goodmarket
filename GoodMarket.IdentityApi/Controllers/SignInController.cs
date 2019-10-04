
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GoodMarket.Application;
using GoodMarket.Application.Exceptions;
using GoodMarket.Application.SignInOut;
using GoodMarket.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoodMarket.IdentityApi.Controllers
{

    /// <summary>
    /// Контроллер входа
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SignInController> _logger;

        public SignInController(ILogger<SignInController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Войти по имени/паролю
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(EmailSignInResponse), 200)]
        public async Task<IActionResult> SignIn([FromBody]EmailSignInRequest request)
        {
            _logger.LogInformation($"Try sign in {request.Email}");
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// Текущий юзер
        /// </summary>
        [HttpGet("Current")]
        [Authorize]
        [ProducesResponseType(typeof(GetCurrentUserResponse), 200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await _mediator.Send(new GetCurrentUserRequest());
            _logger.LogInformation($"Get current user: {result.Email}");
            return Ok(result);
        }

        /// <summary>
        /// Выйти
        /// </summary>
        [HttpGet("SignOut")]
        [Authorize]
        public IActionResult SignOut()
        {
            _logger.LogInformation($"Sign out {User.Identity.Name}");
            return Ok("ok");
        }


    }
}