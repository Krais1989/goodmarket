using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role : IdentityRole<int> {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
