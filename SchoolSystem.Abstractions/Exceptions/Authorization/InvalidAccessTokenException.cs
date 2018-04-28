using Jose;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Authorization
{
    public class InvalidAccessTokenException : SchoolSystemException
    {
        public InvalidAccessTokenException(JoseException exception)
        {
            Exception = exception;
        }

        [Log]
        public JoseException Exception { get; }
    }
}