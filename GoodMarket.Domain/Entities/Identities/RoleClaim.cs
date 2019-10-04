using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain.Entities.Identities
{
    /// <summary>
    /// Связь роль - утверждение
    /// </summary>
    public class RoleClaim : IdentityRoleClaim<int> {

        public virtual Role Role { get; set; }
    }
}
