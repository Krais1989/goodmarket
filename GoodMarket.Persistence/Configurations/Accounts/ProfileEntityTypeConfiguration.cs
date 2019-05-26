using GoodMarket.Application.Serialization;
using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
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

            builder.Property(e => e.Address).HasConversion(e => SSerializer.Serialize(e), e => SSerializer.Deserialize<Address>(e));
        }
    }
}
