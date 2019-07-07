
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
        private readonly GMUserManager _userMan;
        private readonly ILogger<SignInController> _logger;

        public SignInController(ILogger<SignInController> logger, IMediator mediator, GMUserManager userMan)
        {
            _mediator = mediator;
            _logger = logger;
            _userMan = userMan;
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
        [ProducesResponseType(typeof(GetCurrentUserResponseDto), 200)]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userMan.GetUserAsync(User);
            //var user2 = await _userMan.GetUserAsync(User, e => e.UserClaims);
            _logger.LogInformation($"Get current user: {user.Email}");
            return Ok(new GetCurrentUserResponseDto()
            {
                Email = user.Email
            });
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