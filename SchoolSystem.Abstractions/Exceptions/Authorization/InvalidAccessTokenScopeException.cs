using SchoolSystem.Abstractions.Enums;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Authorization
{
    public class InvalidAccessTokenScopeException : SchoolSystemException
    {
        public InvalidAccessTokenScopeException(ScopeFlag receivedScope)
        {
            ReceivedScope = receivedScope;
        }

        [Log]
        public ScopeFlag ReceivedScope { get; }
    }
}