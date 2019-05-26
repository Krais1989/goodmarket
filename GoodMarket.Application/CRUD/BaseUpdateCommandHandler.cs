using GoodMarket.Domain;
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
    public class BaseUpdateCommand<TEntity> : IRequest<TEntity>
    {
        public bool SaveChanges { get; set; } = false;
        public int Id { get; set; }
        public TEntity Entity { get; set; }
        public BaseUpdateCommand(int id, TEntity entity, bool save = true) {

            Id = id;
            Entity = entity;
            SaveChanges = save;
        }
    }

    public class BaseUpdateCommandHandler<TEntity> : IRequestHandler<BaseUpdateCommand<TEntity>, TEntity>
        where TEntity : class
    {
        private GoodMarketDb _db;
        private DbSet<TEntity> _set;
        public BaseUpdateCommandHandler(GoodMarketDb db)
        {
            _db = db;
            _set = db.Set<TEntity>();
        }

        public async Task<TEntity> Handle(BaseUpdateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var entity = await _set.FindAsync(request.Id);
            _db.Entry(entity).CurrentValues.SetValues(request.Entity);
            if (request.SaveChanges)
                await _db.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(entity);
        }
    }
}
