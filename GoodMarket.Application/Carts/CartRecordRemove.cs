using GoodMarket.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application
{
    public class CartRecordRemoveMessage : IRequest
    {
        public int CartId { get; set; }
        public int ProdId { get; set; }
        public bool SaveChanges { get; set; }

        public CartRecordRemoveMessage() { }
        public CartRecordRemoveMessage(int cartId, int prodId, bool save)
        {
            CartId = cartId;
            ProdId = prodId;
            SaveChanges = save;
        }
    }

    public class CartRecordRemove : IRequestHandler<CartRecordRemoveMessage>
    {
        private GoodMarketDbContext _db;
        public CartRecordRemove(GoodMarketDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(CartRecordRemoveMessage request, CancellationToken cancellationToken)
        {
            var cart = await _db.Carts.FindAsync(new object[] { request.CartId }, cancellationToken);
            if (cart == null)
            {
                throw new InvalidOperationException($"Cart not found: id {request.CartId}");
            }

            if (cart.Records == null)
                cart.Records = new Dictionary<int, int>();

            if (cart.Records.ContainsKey(request.ProdId))
                cart.Records.Remove(request.ProdId);

            if (request.SaveChanges)
                await _db.SaveChangesAsync(cancellationToken);
            return await Unit.Task;
        }
    }
}
