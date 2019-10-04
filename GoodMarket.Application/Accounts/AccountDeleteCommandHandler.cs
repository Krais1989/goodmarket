using GoodMarket.Application.CRUD;
using GoodMarket.Domain.Entities.Identities;
using GoodMarket.Persistence;

namespace GoodMarket.Application.Accounts
{
    // TODO: Обработчики Удаления элемента для сущностей

    public class AccountDeleteCommandHandler : BaseDeleteCommandHandler<User>
    {
        public AccountDeleteCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
