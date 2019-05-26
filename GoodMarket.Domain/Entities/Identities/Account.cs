using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Базовый юзер
    /// </summary>
    public class Account : IdentityUser<int>
    {
        public Profile Profile { get; set; }

        public ICollection<AccountClaim> Claims { get; set; }
        public ICollection<AccountLogin> Logins { get; set; }
        public ICollection<AccountToken> Tokens { get; set; }
        public ICollection<AccountRole> AccountRoles { get; set; }
    }

}
