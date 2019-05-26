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
        private GoodMarketDb _db;
        private DbSet<Account> _dbUser;
        public SignInHandler(GoodMarketDb db)
        {
            _db = db;
            _dbUser = _db.Set<Account>();
        }

        public async Task<SignInResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }


}
