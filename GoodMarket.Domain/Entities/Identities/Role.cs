using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain.Entities.Identities
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role : IdentityRole<int> {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
