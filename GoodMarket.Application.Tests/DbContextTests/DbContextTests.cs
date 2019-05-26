using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GoodMarket.Application.Tests.Application
{
    public class TestEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IDictionary<string, string> Props { get; set; }
        public IList<string> SubsNames { get; set; }
    }

    public class TestEntity2DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DbContextTests
    {
        [Fact]
        public void SQLTest()
        {
            using (var db = TestGoodMarketDb.Create())
            {
                var crud = new CRUDWrapper<TestEntity>(db);
                var result = db.Add(new TestEntity() {
                    Name = "Test Entity",
                    SubList = new List<TestEntity2>()
                    {
                        new TestEntity2(){ Name = "Sub Entity 1" },
                        new TestEntity2(){ Name = "Sub Entity 2" },
                    }
                });
                db.SaveChanges();

            }
        }

        [Fact]
        public void Test()
        {
            int count = 1000;
            int count2 = 1000;

            var inc1 = new List<TestEntityDTO>();
            var inc2 = new List<TestEntity2DTO>();

            for (int i = 0; i < count; i++)
            {
                inc1.Add(new TestEntityDTO()
                {
                    Name = $"Entity_{i}",
                    Props = new Dictionary<string, string>()
                    {

                    },
                    SubsNames = new List<string>()
                    {
                        "", ""
                    },
                });
            }

            for (int i = 0; i < count2; i++)
            {

            }

            using (var db = TestGoodMarketDb.Create())
            {
                var crud = new CRUDWrapper<TestEntity>(db);
                var crudSub = new CRUDWrapper<TestEntity2>(db);

                
            }
        }
    }
}
