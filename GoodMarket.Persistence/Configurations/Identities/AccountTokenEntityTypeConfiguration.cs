using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    public class AccountTokenEntityTypeConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.HasOne(e => e.User).WithMany(e => e.UserTokens).HasForeignKey(e => e.UserId);
        }
    }

}
