using System;
using System.Linq;
using System.Text;
using SchoolSystem.Abstractions.Services.Hashing;

namespace SchoolSystem.Domain.Services.Hashing
{
    public abstract class HashServiceBase : IHashServiceBase
    {
        public string GetHashBase64(string textToHash)
        {
            var hash = ComputeHash(textToHash);

            var base64Hash = Convert.ToBase64String(hash);

            return base64Hash;
        }

        public string GetHashHex(string textToHash, string format = "X2")
        {
            var hash = ComputeHash(textToHash);

            var hashInHex = hash.Aggregate(new StringBuilder(), (builder, b) => builder.Append(b.ToString(format)))
                .ToString();

            return hashInHex;
        }

        protected abstract byte[] ComputeHash(string textToHash);
    }
}