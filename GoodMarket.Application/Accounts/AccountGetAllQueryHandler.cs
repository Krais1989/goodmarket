using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики Запросов всех элементов для сущностей

    public class AccountGetAllQueryHandler : BaseGetAllQueryHandler<User>
    {
        public AccountGetAllQueryHandler(GoodMarketDb db) : base(db) { }
    }
}
