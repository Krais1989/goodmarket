using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Identities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Accounts
{
    // TODO: Обработчики Создания элементов для сущностей

    public class AccountCreateCommandHandler : BaseCreateCommandHandler<User>
    {
        public AccountCreateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
