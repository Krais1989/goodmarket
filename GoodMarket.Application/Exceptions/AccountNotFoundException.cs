using GoodMarket.Domain;

namespace GoodMarket.Application.Exceptions
{
    public class AccountNotFoundException : EntityNotFoundException<Account>
    {
        public AccountNotFoundException(string message) : base(message)
        {
        }
    }

}
