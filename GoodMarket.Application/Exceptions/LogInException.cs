using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using GoodMarket.Application.Exceptions.Basics;

namespace GoodMarket.Application.Exceptions
{
    public class InvalidUserNameOrPasswordException : GMException
    {
        public InvalidUserNameOrPasswordException() : base("Invalid user name or password.")
        {
        }

        public InvalidUserNameOrPasswordException(string message) : base(message)
        {
        }
    }

    public class LogInException : GMException
    {
        public LogInException()
        {
        }

        public LogInException(string message) : base(message)
        {
        }

        public LogInException(SignInResult signResult) : base(GetResultString(signResult))
        {

        }

        private static string GetResultString(SignInResult signResult)
        {
            var sb = new StringBuilder();
            if (signResult.IsLockedOut)
                sb.AppendLine("Locked out");
            if (signResult.IsNotAllowed)
                sb.AppendLine("Not allowed");
            if (signResult.RequiresTwoFactor)
                sb.AppendLine("Requires two factor");
            return sb.ToString();
        }
}
}
