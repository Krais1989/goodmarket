using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики Запросов всех элементов для сущностей

    public class AccountGetAllQueryHandler : BaseGetAllQueryHandler<Account>
    {
        public AccountGetAllQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
