using Newtonsoft.Json.Linq;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Authorization
{
    public class AccessTokenWithoutScopesException: SchoolSystemException
    {
        public AccessTokenWithoutScopesException(JObject jwtHeaders)
        {
            JwtHeaders = jwtHeaders;
        }

        [Log]
        public JObject JwtHeaders { get; }
    }
}