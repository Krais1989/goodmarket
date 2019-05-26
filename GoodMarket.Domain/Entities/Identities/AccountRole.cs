using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Связь юзер - роль
    /// </summary>
    public class AccountRole : IdentityUserRole<int> {

        public virtual Account Account { get; set; }
        public virtual Role Role { get; set; }
    }
}
