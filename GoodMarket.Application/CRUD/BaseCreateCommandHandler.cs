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
    public class BaseCreateCommand<TEntity> : IRequest<TEntity>
    {
        public TEntity Entity { get; set; }
        public bool SaveChanges { get; set; }
        public BaseCreateCommand(TEntity entity, bool save = true) {
            Entity = entity;
            SaveChanges = save;
        }
    }

    public class BaseCreateCommandHandler<TEntity> : IRequestHandler<BaseCreateCommand<TEntity>, TEntity>
        where TEntity : class
    {
        private GoodMarketDbContext _db;
        private DbSet<TEntity> _set;
        public BaseCreateCommandHandler(GoodMarketDbContext db)
        {
            _db = db;
            _set = db.Set<TEntity>();
        }

        public async Task<TEntity> Handle(BaseCreateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = await _set.AddAsync(request.Entity, cancellationToken);
            if (request.SaveChanges)
                await _db.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(result.Entity);
        }
    }
}
