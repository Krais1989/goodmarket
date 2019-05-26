using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Конфигурация Аккаунт - Утверждение
    /// </summary>
    public class AccountClaimEntityTypeConfiguration : IEntityTypeConfiguration<AccountClaim>
    {
        public void Configure(EntityTypeBuilder<AccountClaim> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Account).WithMany(e => e.Claims).HasForeignKey(e => e.UserId);
        }
    }
}
