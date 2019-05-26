using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Связь юзер - утверждение
    /// </summary>
    public class AccountClaim : IdentityUserClaim<int> {
        public virtual Account Account { get; set; }
    }
}
