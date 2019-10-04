using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain.Entities.Identities
{
    /// <summary>
    /// Связь юзер - токен
    /// </summary>
    public class UserToken : IdentityUserToken<int> {
        public virtual User User { get; set; }
    }
}
