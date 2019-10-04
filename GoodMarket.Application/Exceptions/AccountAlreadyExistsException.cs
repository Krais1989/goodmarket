using GoodMarket.Application.Exceptions.Basics;
using GoodMarket.Domain;

namespace GoodMarket.Application.Exceptions
{
    public class AccountAlreadyExistsException : GMException
    {
        public AccountAlreadyExistsException()
        {
        }

        public AccountAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
