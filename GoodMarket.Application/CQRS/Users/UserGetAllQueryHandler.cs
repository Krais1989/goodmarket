using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    // TODO: Обработчики Запросов всех элементов для сущностей

    public class UserGetAllQueryHandler : BaseGetAllQueryHandler<User>
    {
        public UserGetAllQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
