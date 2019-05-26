using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Application.Registration
{
    public class RegistrationException : Exception
    {
        public RegistrationException()
        {
        }

        public RegistrationException(string message) : base(message)
        {
        }
    }

    public class RegistrationAccountExistException : RegistrationException
    {
        public RegistrationAccountExistException(int id) : base($"Account with ID:{id} already existing!")
        {
        }
    }

    public class AccountNotExistsException : Exception
    {
        public AccountNotExistsException(int accountId) : base($"Account {accountId} not found!")
        {
        }
    }
}
