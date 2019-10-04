using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain.Entities.Identities
{
    /// <summary>
    /// Связь юзер - утверждение
    /// </summary>
    public class UserClaim : IdentityUserClaim<int> {
        //public virtual User User { get; set; }
    }
}
