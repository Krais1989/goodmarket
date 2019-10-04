using GoodMarket.Domain.Entities.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations.Identities
{
    /// <summary>
    /// Конфигурация Аккаунт - Утверждение
    /// </summary>
    public class AccountClaimEntityTypeConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(e => new { e.Id, e.UserId });
            //builder.HasOne(e => e.User).WithMany(e => e.UserClaims).HasForeignKey(e => e.UserId);
        }
    }
}
