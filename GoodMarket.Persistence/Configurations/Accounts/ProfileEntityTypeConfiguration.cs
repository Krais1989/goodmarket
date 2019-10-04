using GoodMarket.Common;
using GoodMarket.Domain.Entities.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations.Accounts
{
    /// <summary>
    /// Конфигурация профиля
    /// </summary>
    public class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            //builder.HasKey(e => e.Id);
            //builder.HasOne(e => e.Account).WithOne(e => e.Profile).HasForeignKey<Profile>(e => e.AccountId);

            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.AccountId).IsUnique();
            builder.HasOne(e => e.Account).WithOne().HasForeignKey<Profile>(e => e.AccountId);

            builder.Property(e => e.Address).HasConversion(e => SSerializer.SerializeDefault(e), e => SSerializer.DeserializeDefault<Address>(e));
        }
    }
}
