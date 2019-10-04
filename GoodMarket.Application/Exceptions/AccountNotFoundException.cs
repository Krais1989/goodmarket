using GoodMarket.Application.Exceptions.Basics;
using GoodMarket.Domain;

namespace GoodMarket.Application.Exceptions
{
    public class AccountNotFoundException : GMException
    {

        public AccountNotFoundException(string message) : base(message)
        {
        }
    }
}
