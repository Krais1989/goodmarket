using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Конфигурация Аккаунт - Утверждение
    /// </summary>
    public class AccountLoginEntityTypeConfiguration : IEntityTypeConfiguration<AccountLogin>
    {
        public void Configure(EntityTypeBuilder<AccountLogin> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.HasOne(e => e.Account).WithMany(e => e.Logins).HasForeignKey(e => e.UserId);
        }
    }

}
