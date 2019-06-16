using GoodMarket.Application.Exceptions;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application
{
    public class RegistrationRequest : IRequest<RegistrationResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public Profile Profile { get; set; }
    }

    public class RegistrationResponse
    {
        public int Id { get; set; }

        public RegistrationResponse() { }
        public RegistrationResponse(int id)
        {
            Id = id;
        }
    }

    public class RegistrationHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private readonly GMUserManager _userMan;

        public RegistrationHandler(GMUserManager userMan)
        {
            _userMan = userMan;
        }

        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var acc = await _userMan.FindByEmailAsync(request.Email);
            if (acc != null)
                throw new AccountAlreadyExistsException($"Account with email {request.Email} already exists!");

            acc = new User()
            {
                Email = request.Email,
                UserName = request.Email,
                //UserClaims = new List<UserClaim>()
                //{
                //    new UserClaim(){ ClaimType = ClaimTypes.Role, ClaimValue = "Employee"  }
                //}
            };

            var result = await _userMan.CreateAsync(acc, request.Password);
            if (!result.Succeeded)
                throw new AccountCreateException(string.Join("\n", result.Errors.Select(e => e.Description)));

            /* Claim юзера */
            var claimResult = await _userMan.AddClaimAsync(acc, new Claim(ClaimTypes.Role, "Employee"));
            if (!claimResult.Succeeded)
                throw new AccountCreateException(string.Join("\n", claimResult.Errors.Select(e => e.Description)));

            var employees = await _userMan.GetUsersForClaimAsync(new Claim(ClaimTypes.Role, "Employee"));


            return await Task.FromResult(new RegistrationResponse(acc.Id));
        }
    }
}
