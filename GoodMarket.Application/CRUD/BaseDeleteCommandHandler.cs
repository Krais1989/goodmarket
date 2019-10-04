using System.Threading;
using System.Threading.Tasks;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodMarket.Application.CRUD
{
    public class BaseDeleteCommand<TEntity> : IRequest<TEntity>
    {
        public bool SaveChanges { get; set; }
        public TEntity Entity { get; set; }
        public BaseDeleteCommand(TEntity entity, bool save = true) {
            Entity = entity; SaveChanges = save;
        }
    }

    public class BaseDeleteCommandHandler<TEntity> : IRequestHandler<BaseDeleteCommand<TEntity>, TEntity>
        where TEntity : class
    {
        private GoodMarketDbContext _db;
        private DbSet<TEntity> _set;
        public BaseDeleteCommandHandler(GoodMarketDbContext db)
        {
            _db = db;
            _set = db.Set<TEntity>();
        }

        public async Task<TEntity> Handle(BaseDeleteCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = _set.Remove(request.Entity);
            if (request.SaveChanges)
                await _db.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(result.Entity);
        }
    }
}
