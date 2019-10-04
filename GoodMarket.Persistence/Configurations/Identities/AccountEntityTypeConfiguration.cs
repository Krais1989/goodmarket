using GoodMarket.Domain.Entities.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations.Identities
{
    /// <summary>
    /// Базовая конфигурация для Юзера
    /// </summary>
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(e => e.UserRoles).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.UserClaims).WithOne().HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.UserLogins).WithOne(e => e.User).HasForeignKey(e => e.UserId);
            builder.HasMany(e => e.UserTokens).WithOne(e => e.User).HasForeignKey(e => e.UserId);
        }
    }
}
