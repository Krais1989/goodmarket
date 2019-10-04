using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Identities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Accounts
{
    // TODO: Обработчики Запросов всех элементов для сущностей

    public class AccountGetAllQueryHandler : BaseGetAllQueryHandler<User>
    {
        public AccountGetAllQueryHandler(GoodMarketDbContext db) : base(db) { }
    }
}
