using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using GoodMarket.Application.Exceptions;
using GoodMarket.Authentication;
using MediatR;

namespace GoodMarket.Application.SignInOut
{
    /// <summary>
    /// Запрос входа по почте
    /// </summary>
    public class EmailSignInRequest : IRequest<EmailSignInResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Ответ на запрос входа по почте
    /// </summary>
    public class EmailSignInResponse
    {
        public string Login { get; set; }
        public string Token { get; set; }
    }

    public class EmailSignInHandler : IRequestHandler<EmailSignInRequest, EmailSignInResponse>
    {
        private readonly GMUserManager _userMan;
        private readonly IJwtFactory _jwtFactory;

        public EmailSignInHandler(IJwtFactory jwtFactory, GMUserManager userMan)
        {
            _jwtFactory = jwtFactory;
            _userMan = userMan;
        }

        public async Task<EmailSignInResponse> Handle(EmailSignInRequest request, CancellationToken cancellationToken)
        {
            var user = await _userMan.FindByNameAsync(request.Email);
            var result = await _userMan.CheckPasswordAsync(user, request.Password);

            if (!result)
                throw new InvalidUserNameOrPasswordException();
            
            var tokenClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var response = new EmailSignInResponse()
            {
                Login = user.Email,
                Token = _jwtFactory.Generate(tokenClaims)
            };
            return response;
        }
    }


}
