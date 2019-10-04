using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GoodMarket.Persistence;
using MediatR;

namespace GoodMarket.Application.Carts
{
    public class CartRecordQuantityMessage : IRequest
    {
        public int CartId { get; set; }
        public int ProdId { get; set; }
        public int Quantity { get; set; }
        public bool SaveChanges { get; set; }

        public CartRecordQuantityMessage() { }
        public CartRecordQuantityMessage(int cartId, int prodId, int quantity, bool save)
        {
            CartId = cartId;
            ProdId = prodId;
            Quantity = quantity;
            SaveChanges = save;
        }
    }

    public class CartRecordQuantity : IRequestHandler<CartRecordQuantityMessage>
    {
        private GoodMarketDbContext _db;
        public CartRecordQuantity(GoodMarketDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(CartRecordQuantityMessage request, CancellationToken cancellationToken)
        {
            var cart = await _db.Carts.FindAsync(new object[] { request.CartId }, cancellationToken);
            if (cart == null)
            {
                throw new InvalidOperationException($"Cart not found: id {request.CartId}");
            }
            
            if (cart.Records == null)
                cart.Records = new Dictionary<int, int>();

            if (!cart.Records.ContainsKey(request.ProdId))
                cart.Records.Add(request.ProdId, request.Quantity);
            else
                cart.Records[request.ProdId] = request.Quantity;

            // TODO: добавить проверку изменения Dictionary (сам EF Core не работает с Dictionary)
            _db.Entry(cart).Property(e => e.Records).IsModified = true;

            if (request.SaveChanges)
                await _db.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
