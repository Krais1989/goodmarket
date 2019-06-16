using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики команд Изменения для сущностей

    public class AccountUpdateCommandHandler : BaseUpdateCommandHandler<User>
    {
        public AccountUpdateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
