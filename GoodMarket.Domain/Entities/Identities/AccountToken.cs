using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Связь юзер - токен
    /// </summary>
    public class AccountToken : IdentityUserToken<int> {
        public virtual Account Account { get; set; }
    }
}
