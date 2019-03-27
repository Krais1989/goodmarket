using GoodMarket.Application.CQRS;
using GoodMarket.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace GoodMarket.Application.Tests.Application
{
    
    public class CartTests
    {
        [Fact]
        public async void RecordsTest()
        {
            int cartId = -1;
            var ct = new CancellationToken();

            using (var db = new TestGoodMarketDb())
            {
                var crudCart = new CRUDWrapper<Cart>(db);

                var recQuantity = new CartRecordQuantity(db);
                var recRemove = new CartRecordRemove(db);
                
                var cart = await crudCart.Create.Handle(new BaseCreateCommand<Cart>(new Cart(), false), ct);
                cartId = cart.Id;
                await recQuantity.Handle(new CartRecordQuantityMessage(cart.Id, 1, 10, false), ct);
                await recQuantity.Handle(new CartRecordQuantityMessage(cart.Id, 2, 10, false), ct);
                //Assert.True(db.Entry(cart).Property(e => e.Records).IsModified);
                await db.SaveChangesAsync();

                Assert.Contains(1, cart.Records);
                Assert.Equal(10, cart[1]);
                Assert.Contains(2, cart.Records);
                Assert.Equal(10, cart[2]);

                await recRemove.Handle(new CartRecordRemoveMessage(cart.Id, 1, false), ct);
                Assert.DoesNotContain(1, cart.Records);
                Assert.Contains(2, cart.Records);
                Assert.Equal(10, cart[2]);
                //await db.SaveChangesAsync();
            }

            using (var db2 = new TestGoodMarketDb())
            {
                var crudCart = new CRUDWrapper<Cart>(db2);
                var recQuantity = new CartRecordQuantity(db2);
                var recRemove = new CartRecordRemove(db2);

                var cart = await crudCart.Get.Handle(new BaseGetQuery<Cart>(cartId, false), ct);
                Assert.NotNull(cart);
                Assert.DoesNotContain(1, cart.Records);
                Assert.Contains(2, cart.Records);
                Assert.Equal(10, cart[2]);

                cart.Add(66, 100);
                //await db2.SaveChangesAsync();

                var testCart = await crudCart.Get.Handle(new BaseGetQuery<Cart>(cartId, false), ct);
                Assert.NotNull(testCart);
                Assert.Contains(66, testCart.Records);
                Assert.Equal(100, testCart[66]);
            }
        }

        [Fact]
        public async void TestTest()
        {
            int cartId = -1;
            var ct = new CancellationToken();

            using (var db = new TestGoodMarketDb())
            {
                var crudCart = new CRUDWrapper<Cart>(db);
                var recQuantity = new CartRecordQuantity(db);
                var recRemove = new CartRecordRemove(db);

                var cart = await crudCart.Create.Handle(new BaseCreateCommand<Cart>(new Cart(), false), ct);
                await db.SaveChangesAsync();
                cartId = cart.Id;
                await recQuantity.Handle(new CartRecordQuantityMessage(cart.Id, 1, 10, false), ct);
            }

            using (var db = new TestGoodMarketDb())
            {
                var crudCart = new CRUDWrapper<Cart>(db);
                var recQuantity = new CartRecordQuantity(db);
                var recRemove = new CartRecordRemove(db);

                var cart = await crudCart.Get.Handle(new BaseGetQuery<Cart>(cartId, false), ct);
                Assert.DoesNotContain(1, cart.Records);
            }
        }
    }
}
