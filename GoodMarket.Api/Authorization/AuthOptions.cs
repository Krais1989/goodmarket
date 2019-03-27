using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Api.Authorization
{
    public class AuthOptions
    {
        public const string ISSUER = "GoodMarketServer";           // Издатель токена
        public const string AUDIENCE = "http://goodmarket.com";    // Потребитель токена
        public const string SKEY = "test_secret_key_qweqwe123123123123123weqwe";     // Секретный ключ
        public const int LIFETIME = 60;    // Время жизни токена в минутах
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SKEY));
        }
    }
}
