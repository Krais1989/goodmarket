using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    public class AccountTokenEntityTypeConfiguration : IEntityTypeConfiguration<AccountToken>
    {
        public void Configure(EntityTypeBuilder<AccountToken> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.HasOne(e => e.Account).WithMany(e => e.Tokens).HasForeignKey(e => e.UserId);
        }
    }

}
