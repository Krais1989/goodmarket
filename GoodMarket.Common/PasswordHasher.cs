using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GoodMarket.Common
{
    public static class PasswordHasher
    {
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int HasingIterationsCount = 1000;

        public static string ComputeHash(string password)
        {
            using (RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltByteSize];
                saltGenerator.GetBytes(salt);

                using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt))
                {
                    hashGenerator.IterationCount = HasingIterationsCount;
                    return Convert.ToBase64String(hashGenerator.GetBytes(HashByteSize));
                }
            }
        }
    }
}
