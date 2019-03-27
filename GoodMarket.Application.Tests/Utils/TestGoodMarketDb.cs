using GoodMarket.Application.Tests.Application;
using GoodMarket.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Application.Tests
{
    public class TestGoodMarketDb : GoodMarketDb
    {
        public static readonly LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
            new DebugLoggerProvider()
        });

        
        public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<TestEntity2> TestSubEntities { get; set; }

        public TestGoodMarketDb() : base() { }
        public TestGoodMarketDb(DbContextOptions opts) : base(opts) { }
        
        public static TestGoodMarketDb Create(string dbName = "test_mem_db")
        {
            var opts = new DbContextOptionsBuilder<TestGoodMarketDb>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            return new TestGoodMarketDb(opts);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            _myLoggerFactory.AddConsole(LogLevel.Information);

            optionsBuilder.UseInMemoryDatabase(databaseName: "db_dbmarket");
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestGoodMarketDb).Assembly);
        }
    }
}
