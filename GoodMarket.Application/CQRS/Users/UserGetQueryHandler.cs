using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    // TODO: Обработчики Запросов элемента для сущностей

    public class UserGetQueryHandler : BaseGetQueryHandler<User>
    {
        public UserGetQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
