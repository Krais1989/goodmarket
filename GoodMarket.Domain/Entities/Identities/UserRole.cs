using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain.Entities.Identities
{
    /// <summary>
    /// Связь юзер - роль
    /// </summary>
    public class UserRole : IdentityUserRole<int> {

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
