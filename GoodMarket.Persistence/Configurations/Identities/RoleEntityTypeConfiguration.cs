using GoodMarket.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodMarket.Persistence.Configurations
{
    /// <summary>
    /// Конфигурация для Роли
    /// </summary>
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.UserRoles).WithOne(e => e.Role).HasForeignKey(e => e.RoleId);
            builder.HasMany(e => e.RoleClaims).WithOne(e => e.Role).HasForeignKey(e => e.RoleId);
        }
    }

}
