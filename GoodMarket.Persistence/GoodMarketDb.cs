using GoodMarket.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace GoodMarket.Persistence
{
    public class GoodMarketDb : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public GoodMarketDb() {

        }
        public GoodMarketDb(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoodMarketDb).Assembly);
            //modelBuilder.Entity<Product>().Property(e => e.ID).IsRequired();
        }
    }
}
