using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики команд Изменения для сущностей

    public class AccountUpdateCommandHandler : BaseUpdateCommandHandler<User>
    {
        public AccountUpdateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
