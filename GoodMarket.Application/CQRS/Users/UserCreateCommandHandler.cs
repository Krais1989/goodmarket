using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    // TODO: Обработчики Создания элементов для сущностей

    public class UserCreateCommandHandler : BaseCreateCommandHandler<User>
    {
        public UserCreateCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
