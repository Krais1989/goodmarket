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
    public class User : IdentityUser<int>
    {
        public ICollection<UserClaim> UserClaims { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }

}
