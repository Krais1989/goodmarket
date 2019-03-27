using GoodMarket.Application.CQRS;
using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    /// <summary>
    /// Обёртка под CRUD CQRS
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseCRUDWrapper<T> where T: class, IEntity, new()
    {
        public BaseGetQueryHandler<T> Get { get; private set; }
        public BaseGetAllQueryHandler<T> GetAll { get; private set; }
        public BaseAttachCommandHandler<T> Attach { get; private set; }
        public BaseCreateCommandHandler<T> Create { get; private set; }
        public BaseUpdateCommandHandler<T> Update { get; private set; }
        public BaseDeleteCommandHandler<T> Delete { get; private set; }

        public BaseCRUDWrapper(GoodMarketDb db)
        {
            Get = new BaseGetQueryHandler<T>(db);
            GetAll = new BaseGetAllQueryHandler<T>(db);
            Attach = new BaseAttachCommandHandler<T>(db);
            Create = new BaseCreateCommandHandler<T>(db);
            Update = new BaseUpdateCommandHandler<T>(db);
            Delete = new BaseDeleteCommandHandler<T>(db);
        }
    }
}
