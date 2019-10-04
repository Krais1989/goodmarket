using Microsoft.AspNetCore.Identity;

namespace GoodMarket.Domain.Entities.Identities
{
    /// <summary>
    /// Связь юзер - вход
    /// </summary>
    public class UserLogin: IdentityUserLogin<int> {
        public virtual User User { get; set; }
    }
}
