using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики команд Изменения для сущностей

    public class AccountUpdateCommandHandler : BaseUpdateCommandHandler<Account>
    {
        public AccountUpdateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
