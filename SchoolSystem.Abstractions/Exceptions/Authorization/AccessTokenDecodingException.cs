using System;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Authorization
{
    public class AccessTokenDecodingException : SchoolSystemException
    {
        public AccessTokenDecodingException(Exception exception)
        {
            Exception = exception;
        }

        [Log]
        public Exception Exception { get; }
    }
}