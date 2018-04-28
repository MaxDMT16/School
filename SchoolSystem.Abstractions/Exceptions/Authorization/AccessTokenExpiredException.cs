using System;
using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Authorization
{
    public class AccessTokenExpiredException : SchoolSystemException
    {
        public AccessTokenExpiredException(DateTime expirationDate)
        {
            ExpirationDate = expirationDate;
        }

        [Log]
        public DateTime ExpirationDate { get; }
    }
}