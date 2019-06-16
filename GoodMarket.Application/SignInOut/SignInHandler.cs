using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GoodMarket.Domain;
using GoodMarket.Application.Serialization;
using GoodMarket.Persistence;
using Microsoft.EntityFrameworkCore;
using GoodMarket.Application.Exceptions;
using GoodMarket.Authentication;
using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Application
{
    public class SignInRequest : IRequest<SignInResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInResponse
    {
        public string Login { get; set; }
        public string Token { get; set; }
    }

    public class SignInHandler : IRequestHandler<SignInRequest, SignInResponse>
    {
        private readonly GMSignInManager _signMan;
        private readonly GMUserManager _userMan;
        private readonly IJwtFactory _jwtFactory;

        public SignInHandler(IJwtFactory jwtFactory, GMUserManager userMan, GMSignInManager signMan)
        {
            _jwtFactory = jwtFactory;
            _userMan = userMan;
            _signMan = signMan;
        }

        public async Task<SignInResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var user = await _userMan.FindByNameAsync(request.Email);
            var result = await _userMan.CheckPasswordAsync(user, request.Password);
            if (!result)
                throw new InvalidUserNameOrPasswordException();

            var claims = await _userMan.GetClaimsAsync(user);

            var tokenClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, request.Email)
            };
            var response = new SignInResponse()
            {
                Login = request.Email,
                Token = _jwtFactory.Generate(tokenClaims)
            };
            return response;
        }
    }


}
