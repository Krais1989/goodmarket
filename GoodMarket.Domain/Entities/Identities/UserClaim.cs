using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Связь юзер - утверждение
    /// </summary>
    public class UserClaim : IdentityUserClaim<int> {
        public virtual User User { get; set; }
    }
}
