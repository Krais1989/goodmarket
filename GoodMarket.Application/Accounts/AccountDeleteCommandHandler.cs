using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики Удаления элемента для сущностей

    public class AccountDeleteCommandHandler : BaseDeleteCommandHandler<Account>
    {
        public AccountDeleteCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
