using System.Security.Cryptography;
using System.Text;
using SchoolSystem.Abstractions.Services.Hashing;

namespace SchoolSystem.Domain.Services.Hashing
{
    public class Md5HashingService : HashServiceBase, IMd5HashingService
    {
        protected override byte[] ComputeHash(string textToHash)
        {
            var textToHashBytes = Encoding.UTF8.GetBytes(textToHash);

            using (var md5CryptoServiceProvider = new MD5CryptoServiceProvider())
            {
                var hash = md5CryptoServiceProvider.ComputeHash(textToHashBytes);

                return hash;
            }
        }
    }
}