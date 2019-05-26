using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain
{
    /// <summary>
    /// Связь юзер - вход
    /// </summary>
    public class AccountLogin: IdentityUserLogin<int> {
        public virtual Account Account { get; set; }
    }
}
