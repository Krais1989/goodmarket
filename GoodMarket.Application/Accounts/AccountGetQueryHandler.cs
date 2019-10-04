using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Identities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Accounts
{
    // TODO: Обработчики Запросов элемента для сущностей

    public class AccountGetQueryHandler : BaseGetQueryHandler<User>
    {
        public AccountGetQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
