using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики Создания элементов для сущностей

    public class AccountCreateCommandHandler : BaseCreateCommandHandler<Account>
    {
        public AccountCreateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
