using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Application.Tokens
{
    public interface IJwtFactory
    {
        string Generate();
    }

    public class JwtFactory : IJwtFactory
    {
        public string Generate()
        {
            throw new NotImplementedException();
        }
    }
}
