using GoodMarket.Application.Tests.Application;
using GoodMarket.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GoodMarket.Application.Tests
{
    public class TestGoodMarketDb : GoodMarketDb
    {        
        public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<TestEntity2> TestSubEntities { get; set; }

        public TestGoodMarketDb(DbContextOptions opts) : base(opts) { }

        public static TestGoodMarketDb Create(string dbName = "test_mem_db")
        {
            var opts = new DbContextOptionsBuilder<TestGoodMarketDb>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            return new TestGoodMarketDb(opts);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestGoodMarketDb).Assembly);
        }
    }
}
