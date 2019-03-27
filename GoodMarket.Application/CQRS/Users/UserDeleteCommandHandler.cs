using GoodMarket.Domain;
using GoodMarket.Persistence;

namespace GoodMarket.Application.CQRS
{
    // TODO: Обработчики Удаления элемента для сущностей

    public class UserDeleteCommandHandler : BaseDeleteCommandHandler<User>
    {
        public UserDeleteCommandHandler(GoodMarketDb db) : base(db) { }
    }
}
