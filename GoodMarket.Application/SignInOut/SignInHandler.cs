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
        private readonly IJwtFactory _jwtFactory;
        private readonly GoodMarketDb _db;
        private DbSet<Account> _dbUser;


        public SignInHandler(IJwtFactory jwtFactory, GoodMarketDb db)
        {
            _db = db;
            _dbUser = _db.Set<Account>();
            _jwtFactory = jwtFactory;
        }

        public async Task<SignInResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, request.Email)
            };

            var response = new SignInResponse()
            {
                Login = request.Email,
                Token = _jwtFactory.Generate(claims)
            };
            return response;
        }
    }


}
