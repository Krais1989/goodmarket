using GoodMarket.Application.CQRS;
using GoodMarket.Domain;
using GoodMarket.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GoodMarket.Application.Tests
{
    public class CrudTests
    {
        private readonly ITestOutputHelper _output;

        public CrudTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async void TestCustomers()
        {
            await TestEntityCRUD_OneContext(1000, 1000 * 2, 500,
                (i) => new Customer() { Email = $"Customer_{i + 1}", Cart = new Cart() },                
                (e) => { Assert.EndsWith($"_{e.Id}", e.Email); },
                (e, db) => { e.Email += $"_upd{e.Id}"; },
                (e) => { e.Email.EndsWith($"_upd{e.Id}"); });
        }

        [Fact]
        public async void TestProducts()
        {
            await TestEntityCRUD_OneContext(1000, 1000, 500,
                (i) => new Product() { Title = $"Product_{i + 1}", Price = (i+1) * 10 },                
                (e) => { Assert.EndsWith($"_{e.Id}", e.Title); Assert.Equal(e.Id * 10, e.Price); },
                (e, db) => { e.Title += $"_upd{e.Id}"; e.Price += 55.5m; },
                (e) => { e.Title.EndsWith($"_upd{e.Id}"); Assert.Equal((e.Id * 10)+55.5m, e.Price); });
        }

        [Fact]
        public async void TestCart()
        {
            await TestEntityCRUD_OneContext(1000, 1000, 500,
                (i) => new Cart() { Records = new Dictionary<int, int>() { { 1, i + 1 } } },                
                (e) => { Assert.Contains(1, e.Records); Assert.Equal(e.Id, e.Records[1]); },
                (e, db) => { e.Add(1, 1); db.Entry(e).Property(p => p.Records).IsModified = true; },
                (e) => { Assert.Contains(1, e.Records); Assert.Equal(e.Id + 1, e.Records[1]); });
        }

        /*
            await TestEntity(count, // ����� ����������� ���������
                createCount,        // ����� ��������� ���������(��������� ��������� ��������)
                (i) => {  },    // i - 0..count. ����� �������� ��������
                (e) => {  },    // e - entity. ��������� �������� ���������� entity
                (e) => {  },    // e - entity. ��������� ��������� entity
                (e) => {  });   // e - entity. ��������� �������� ��������� entity
            */

        /// <summary>
        /// ���������� ��������� �������� CRUD �������� � ����� ���������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">����� ����������� ���������</param>
        /// <param name="createdCount">c - ����� ��������� � ����� ���������. 
        /// <param name="deletedCount">c - ����� �������� � ����� ���������. 
        /// <param name="createFunc">i - [0..count]. ����� �������� ��������</param>
        /// <param name="createCheckFunc">e - entity. ��������� �������� ���������� entity</param>
        /// <param name="updateFunc">e - entity. ��������� ��������� entity</param>
        /// <param name="updateCheckFunc">e - entity. ��������� �������� ��������� entity</param>
        /// <returns></returns>
        private async Task TestEntityCRUD_OneContext<T>(int count, int createdCount, int deletedCount,
                                            Func<int, T> createFunc,
                                            Action<T> createCheckFunc,
                                            Action<T, TestGoodMarketDb> updateFunc,
                                            Action<T> updateCheckFunc)

            where T : class, IEntity, new()
        {

            using (var db = TestGoodMarketDb.Create())
            {
                var ct = new CancellationToken();
                var cqrs = new CRUDWrapper<T>(db);

                /* ������� count ������� */
                for (int i = 0; i < count; i++)
                {
                    var entity = await cqrs.Attach.Handle(new BaseAttachCommand<T>(createFunc(i), false), ct);
                }
                Assert.Equal(createdCount, await db.SaveChangesAsync());

                /* �������� ��������� ������� */
                var untrackEntities1 = await cqrs.GetAll.Handle(new BaseGetAllQuery<T>(false), ct);
                foreach (var entity in untrackEntities1)
                {
                    createCheckFunc(entity);
                }

                /* �������� count �������, ������� �� ������ */
                var trackEntities = await cqrs.GetAll.Handle(new BaseGetAllQuery<T>(true), ct);
                foreach (var entity in trackEntities)
                {
                    updateFunc(entity, db);
                    await cqrs.Update.Handle(new BaseUpdateCommand<T>(entity, false), ct);
                }

                Assert.Equal(count, await db.SaveChangesAsync());
                //_output.WriteLine($"Updates: {await db.SaveChangesAsync()}");
                

                /* ��������� ��������� */
                var untrackEntities2 = await cqrs.GetAll.Handle(new BaseGetAllQuery<T>(false), ct);
                foreach (var cust in untrackEntities2)
                {
                    updateCheckFunc(cust);
                }

                /* �������� �������� ������� */
                var trackEntities2 = await cqrs.GetAll.Handle(new BaseGetAllQuery<T>(true), ct);
                foreach (var cust in trackEntities2)
                {
                    if (cust.Id % 2 == 0) // �������� ���� ������ �������
                    {
                        await cqrs.Delete.Handle(new BaseDeleteCommand<T>(cust, false), ct);
                    }
                }
                Assert.Equal(deletedCount, await db.SaveChangesAsync());
                
                /* �������� ���������� ������� */
                var leftCust = (await cqrs.GetAll.Handle(new BaseGetAllQuery<T>(false), ct)).ToList();
                Assert.Equal(count - deletedCount, leftCust.Count);
            }
        }
    }
}
