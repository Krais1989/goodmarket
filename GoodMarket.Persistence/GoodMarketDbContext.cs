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
    /// <summary>
    /// Контекст БД с основными доменными объектами
    /// </summary>
    public class GoodMarketDbContext : DbContext
    {
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
        
        public GoodMarketDbContext(DbContextOptions<GoodMarketDbContext> options) : base(options)
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoodMarketDbContext).Assembly);
        }
    }
}
