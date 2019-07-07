using GoodMarket.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        //public async override Task<User> GetUserAsync(ClaimsPrincipal principal)
        //{
        //    var result = await Users
        //        .Include(e => e.UserClaims)
        //        .SingleOrDefaultAsync(e => e.UserName == principal.GetName());
        //    return result;
        //}

        public async virtual Task<User> GetUserAsync<TProperty>(ClaimsPrincipal principal, Expression<Func<User, TProperty>> navigationPropertyPath = null)
        {
            var result = await (navigationPropertyPath == null ? Users : Users.Include(e => navigationPropertyPath))
                .SingleOrDefaultAsync(e => e.UserName == principal.GetName());

            return result;
        }
    }
}
