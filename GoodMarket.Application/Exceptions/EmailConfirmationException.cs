using System;
using System.Collections.Generic;
using System.Text;

namespace GoodMarket.Application.Exceptions
{
    public class EmailConfirmationException : GMException
    {
        public EmailConfirmationException(string email) : base($"Email {email} confirmation error!")
        {
        }
    }
}
