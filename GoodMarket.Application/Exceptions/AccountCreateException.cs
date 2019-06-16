namespace GoodMarket.Application.Exceptions
{
    public class AccountCreateException : GMException
    {
        public AccountCreateException()
        {
        }

        public AccountCreateException(string message) : base(message)
        {
        }
    }
}
