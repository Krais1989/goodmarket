using System.Threading;
using System.Threading.Tasks;
using GoodMarket.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GoodMarket.Application.CRUD
{
    public class BaseGetQuery<T> : IRequest<T>
    {
        public int Id { get; set; }
        public BaseGetQuery(int id) { Id = id; }
        //public bool Track { get; set; } = false;
        //public BaseGetQuery(int id, bool track = false) { Id = id; Track = track; }
    }

    public class BaseGetQueryHandler<TEntity> : IRequestHandler<BaseGetQuery<TEntity>, TEntity>
        where TEntity : class
    {
        protected DbSet<TEntity> _set;

        public BaseGetQueryHandler(GoodMarketDbContext db)
        {
            _set = db.Set<TEntity>();
        }
        public virtual async Task<TEntity> Handle(BaseGetQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await _set.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
