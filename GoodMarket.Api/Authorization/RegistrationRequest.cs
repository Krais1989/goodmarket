using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Api.Authorization
{
    public class RegistrationResponse
    {
        public bool Success { get; set; } = false;

        public RegistrationResponse() { }
        public RegistrationResponse(bool success)
        {
            Success = success;
        }
    }

    public class RegistrationRequest : IRequest<RegistrationResponse>
    {
        public User Data { get; set; }
    }

    public class RegistrationHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private GoodMarketDb _db;
        private DbSet<User> _dbUser;
        public RegistrationHandler(GoodMarketDb db)
        {
            _db = db;
            _dbUser = _db.Set<User>();
        }

        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbUser.FindAsync(request.Data.Id);
            if (user != null) return new RegistrationResponse(false);
            user = request.Data;
            user.Id = 0;
            user.Role = 0;
            _dbUser.Add(user);
            await _db.SaveChangesAsync();
            return await Task.FromResult(new RegistrationResponse(true));
        }
    }
}
