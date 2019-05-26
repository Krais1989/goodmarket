using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики Запросов элемента для сущностей

    public class AccountGetQueryHandler : BaseGetQueryHandler<Account>
    {
        public AccountGetQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
