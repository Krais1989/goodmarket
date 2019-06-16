using GoodMarket.Domain;
using GoodMarket.Persistence;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodMarket.IdentityApi
{
    /// <summary>
    /// Контекст БД для обслуживания аккаунтов
    /// </summary>
    public class GoodMarketIdentityDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public GoodMarketIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Настройка identity-пользователя */
            builder.Entity<User>(e =>
            {
                e.ToTable("AspNetUsers");
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                e.HasIndex(x => x.NormalizedEmail).HasName("EmailIndex");

                e.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();

                e.HasMany(x => x.UserClaims).WithOne().HasForeignKey(x => x.UserId);
                e.HasMany(x => x.UserLogins).WithOne(x => x.User).HasForeignKey(x => x.UserId);
                e.HasMany(x => x.UserTokens).WithOne(x => x.User).HasForeignKey(x => x.UserId);
                e.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            });

            /* Настройка identity-роли */
            builder.Entity<Role>(e =>
            {
                e.ToTable("AspNetRoles");
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.NormalizedName).HasName("RoleNameIndex").IsUnique();

                e.Property(x => x.ConcurrencyStamp).IsConcurrencyToken();

                e.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
                e.HasMany(x => x.RoleClaims).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
            });

            /* Настройка пользователь-утверждение */
            builder.Entity<UserClaim>(e =>
            {
                e.ToTable("AspNetUserClaims");
                e.HasKey(x => new { x.Id, x.UserId });
            });

            /* Настройка пользователь-вход */
            builder.Entity<UserLogin>(e =>
            {
                e.ToTable("AspNetUserLogins");
                e.HasKey(x => new { x.LoginProvider, x.ProviderKey });
            });

            /* Настройка пользователь-токен */
            builder.Entity<UserToken>(e =>
            {
                e.ToTable("AspNetUserTokens");
                e.HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
            });

            /* Настройка роль-утверждение */
            builder.Entity<RoleClaim>(e =>
            {
                e.ToTable("AspNetRoleClaims");
                e.HasKey(x => x.Id);
            });

            /* Настройка пользователь-роль */
            builder.Entity<UserRole>(e =>
            {
                e.ToTable("AspNetUserRoles");
                e.HasKey(x => new { x.UserId, x.RoleId });
            });
        }
    }
}
