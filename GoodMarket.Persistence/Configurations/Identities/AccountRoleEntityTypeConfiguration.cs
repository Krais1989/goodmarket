using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    public class AccountRoleEntityTypeConfiguration : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> builder)
        {
            builder.HasKey(e => new { e.UserId, e.RoleId });
            builder.HasOne(e => e.Account).WithMany(e => e.AccountRoles).HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Role).WithMany(e => e.AccountRoles).HasForeignKey(e => e.RoleId);
        }
    }

}
