using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application
{
    // TODO: Обработчики Создания элементов для сущностей

    public class AccountCreateCommandHandler : BaseCreateCommandHandler<User>
    {
        public AccountCreateCommandHandler(GoodMarketDbContext db) : base(db) { }
    }
}
