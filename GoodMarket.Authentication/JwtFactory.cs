using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoodMarket.Authentication
{
    public interface IJwtFactory
    {
        string Generate(IEnumerable<Claim> Claims);
    }

    /// <summary>
    /// Фабрика JWT токенов
    /// </summary>
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtSettings _jwtSettings;

        public JwtFactory(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string Generate(IEnumerable<Claim> claims)
        {
            /* Генерация токена */
            var jwtToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_jwtSettings.AccessExpiration),
                    signingCredentials: _jwtSettings.GetSigningCredentials() // Подпись
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
