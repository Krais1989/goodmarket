using GoodMarket.Domain;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace GoodMarket.Persistence
{
    public abstract class IdentityDbContext<
    TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : IdentityUserContext<TUser, TKey, TUserClaim, TUserLogin, TUserToken>
     where TKey : IEquatable<TKey>
     where TUser : IdentityUser<TKey>
     where TRole : IdentityRole<TKey>
     where TUserClaim : IdentityUserClaim<TKey>
     where TUserRole : IdentityUserRole<TKey>
     where TUserLogin : IdentityUserLogin<TKey>
     where TRoleClaim : IdentityRoleClaim<TKey>
     where TUserToken : IdentityUserToken<TKey>
    {
        public DbSet<Role> Roles { get; set; }

        public IdentityDbContext(DbContextOptions options) : base(options)
        {
        }
    }


    public class GoodMarketDb : IdentityDbContext<int, Account, Role, AccountClaim, AccountRole, AccountLogin, RoleClaim, AccountToken>
    {
        /* Identity-юзеры */

        /* Юзеры бизнес-логики */
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Cart> Carts { get; set; }

        /* Продукты */
        public DbSet<Product> Products { get; set; }
        public DbSet<Domain.Attribute> Attributes { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Category> Categories { get; set; }

        /* Заказы */
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderHistory> OrderLogs { get; set; }

        /* Поставщики */
        public DbSet<Supplier> Suppliers { get; set; }
        
        public GoodMarketDb(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* Автоматической применение всех конфигов IEntityTypeConfiguration из текущей сборки */
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoodMarketDb).Assembly);
        }
    }
}
