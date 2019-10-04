using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using GoodMarket.Application.Exceptions;
using GoodMarket.Domain.Entities.Identities;
using MediatR;

namespace GoodMarket.Application.Registration
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
        public string DebugEmailToken { get; set; }

        public RegistrationResponse() { }
        public RegistrationResponse(int id)
        {
            Id = id;
        }
    }

    public class RegistrationHandler : IRequestHandler<RegistrationRequest, RegistrationResponse>
    {
        private readonly GMUserManager _userMan;
        private readonly GMRoleManager _roleMan;
        private readonly IMediator _mediator;

        public RegistrationHandler(GMUserManager userMan, GMRoleManager roleMan, IMediator mediator)
        {
            _userMan = userMan;
            _roleMan = roleMan;
            _mediator = mediator;
        }
        
        public async Task<RegistrationResponse> Handle(RegistrationRequest request, CancellationToken cancellationToken)
        {
            var user = await _userMan.FindByEmailAsync(request.Email);
            if (user != null)
                throw new AccountAlreadyExistsException($"Account with email {request.Email} already exists!");

            user = new User()
            {
                Email = request.Email,
                UserName = request.Email,
                //UserClaims = new List<UserClaim>()
                //{
                //    new UserClaim(){ ClaimType = ClaimTypes.Role, ClaimValue = "Employee"  }
                //}
            };

            var userCreateRes = await _userMan.CreateAsync(user, request.Password);
            if (!userCreateRes.Succeeded)
                throw new AccountCreateException(string.Join("\n", userCreateRes.Errors.Select(e => e.Description)));

            /* Новая роль Employee */
            if (!(await _roleMan.RoleExistsAsync("Employee")))
            {
                var roleCreateRes = await _roleMan.CreateAsync(new Role()
                {
                    Name = "Employee",
                    RoleClaims = new List<RoleClaim>()
                    {
                        new RoleClaim(){ ClaimType="RoleClaim", ClaimValue = "RoleEmployee" }
                    }

                });
                if (!roleCreateRes.Succeeded)
                {
                    throw new AccountCreateException(string.Join("\n", roleCreateRes.Errors.Select(e => e.Description)));
                }
            }

            /* Добавление юзера в Employee */
            var userRoleAdd = await _userMan.AddToRoleAsync(user, "Employee");
            if (!userRoleAdd.Succeeded)
            {
                throw new AccountCreateException(string.Join("\n", userRoleAdd.Errors.Select(e => e.Description)));
            }

            /* Claim юзера */
            var claimResult = await _userMan.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Employee"));
            if (!claimResult.Succeeded)
                throw new AccountCreateException(string.Join("\n", claimResult.Errors.Select(e => e.Description)));

            var emailConfirmToken = await _userMan.GenerateEmailConfirmationTokenAsync(user);

            return await Task.FromResult(new RegistrationResponse(user.Id) { DebugEmailToken = emailConfirmToken });
        }
    }
}
