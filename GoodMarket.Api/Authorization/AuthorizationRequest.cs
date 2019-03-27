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
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace GoodMarket.Api.Authorization
{
    public class AuthorizationResponse
    {
        public string Login { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }

    public class AuthorizationRequest : IRequest<AuthorizationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthorizationHandler : IRequestHandler<AuthorizationRequest, AuthorizationResponse>
    {
        private GoodMarketDb _db;
        private DbSet<User> _dbUser;
        public AuthorizationHandler(GoodMarketDb db)
        {
            _db = db;
            _dbUser = _db.Set<User>();
        }

        public async Task<AuthorizationResponse> Handle(AuthorizationRequest request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.SingleOrDefaultAsync(e => e.Email == request.Email && e.Password == request.Password);
            if (user == null)
            {
                return await Task.FromResult(new AuthorizationResponse()
                {
                    ErrorMessage = $"Invalid email or password.",
                    Success = false
                });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            var identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.UtcNow,
                    claims: identity.Claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            var encjwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return await Task.FromResult(new AuthorizationResponse()
            {
                Login = identity.Name,
                Token = encjwt,
                Success = true
            });
        }
    }


}
