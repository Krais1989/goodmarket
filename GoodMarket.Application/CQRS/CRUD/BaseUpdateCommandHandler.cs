using GoodMarket.Domain;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoodMarket.Application.CQRS
{
    public class BaseUpdateCommand<TEntity> : IRequest<TEntity>
        where TEntity : IEntity
    {
        public bool SaveChanges { get; set; } = false;
        public TEntity Entity { get; set; }
        public BaseUpdateCommand(TEntity entity, bool save = true) {
            Entity = entity;
            SaveChanges = save;
        }
    }

    public class BaseUpdateCommandHandler<TEntity> : IRequestHandler<BaseUpdateCommand<TEntity>, TEntity>
        where TEntity : class, IEntity
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
            var result = _set.Update(request.Entity);
            if (request.SaveChanges)
                await _db.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(result.Entity);
        }
    }
}
