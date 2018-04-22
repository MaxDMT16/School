using System;
using System.Security.Cryptography;
using SchoolSystem.Abstractions.Services.RandomString;

namespace SchoolSystem.Domain.Services.RandomString
{
    public class RandomStringService : IRandomStringService
    {
        public string Generate(int length)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[length];

                rngCryptoServiceProvider.GetBytes(bytes);

                var fromBase64String = Convert.ToBase64String(bytes);

                return fromBase64String;
            }
        }
    }
}