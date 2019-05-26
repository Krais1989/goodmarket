using GoodMarket.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodMarket.Persistence
{
    public class AccountManager : UserManager<Account>
    {
        public AccountManager(IUserStore<Account> store, 
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<Account> passwordHasher, 
            IEnumerable<IUserValidator<Account>> userValidators, 
            IEnumerable<IPasswordValidator<Account>> passwordValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<Account>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public virtual async Task<Account> FindByIdAsync(int id)
        {
            return await FindByIdAsync(Convert.ToString(id));
        }
    }
}
