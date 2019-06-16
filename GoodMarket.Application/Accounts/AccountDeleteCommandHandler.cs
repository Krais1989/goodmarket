using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики Удаления элемента для сущностей

    public class AccountDeleteCommandHandler : BaseDeleteCommandHandler<User>
    {
        public AccountDeleteCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
