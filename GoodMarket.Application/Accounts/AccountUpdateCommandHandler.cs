using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Identities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Accounts
{
    // TODO: Обработчики команд Изменения для сущностей

    public class AccountUpdateCommandHandler : BaseUpdateCommandHandler<User>
    {
        public AccountUpdateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
