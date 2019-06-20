using GoodMarket.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application
{
    /// <summary>
    /// Менеджер юзеров
    /// </summary>
    public class GMUserManager : UserManager<User>
    {
        public GMUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public override Task<User> FindByNameAsync(string userName)
        {
            return base.FindByNameAsync(userName);
            //var result = await base.FindByNameAsync(userName);
            //result.UserClaims = await GetClaimsAsync(result);
            //return result;
        }
    }

    /// <summary>
    /// Менеджер юзеров
    /// </summary>
    public class GMRoleManager : RoleManager<Role>
    {
        public GMRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) 
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }

    /// <summary>
    /// Менеджер входа
    /// </summary>
    public class GMSignInManager : SignInManager<User>
    {
        public GMSignInManager(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }
    }
}
