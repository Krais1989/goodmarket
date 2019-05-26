using GoodMarket.Application.Registration;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application
{
    public class RegistrationResponse
    {
        public int Id { get; set; }

        public RegistrationResponse() { }
        public RegistrationResponse(int id)
        {
            Id = id;
        }
    }

    public class RegistrationRequest : IRequest<RegistrationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }

    }

    public class RegistrationHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private readonly GoodMarketDb _db;
        private readonly DbSet<Account> _dbUser;
        private readonly AccountManager _accMan;
        public RegistrationHandler(GoodMarketDb db, AccountManager accMan)
        {
            _db = db;
            _dbUser = _db.Set<Account>();
            _accMan = accMan;
        }

        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var acc = await _accMan.FindByEmailAsync(request.Email);
            if (acc != null)
                throw new RegistrationException();

            acc = new Account()
            {
                Email = request.Email,
                UserName = request.Email,
                Profile = request.Profile
            };
            var result = await _accMan.CreateAsync(acc);
            if (!result.Succeeded)
                throw new RegistrationException(string.Join("\n", result.Errors.Select(e => e.Description)));
            return await Task.FromResult(new RegistrationResponse(acc.Id));
        }
    }
}
