using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    // TODO: Обработчики команд Изменения для сущностей

    public class UserUpdateCommandHandler : BaseUpdateCommandHandler<User>
    {
        public UserUpdateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
