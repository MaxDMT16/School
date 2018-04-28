using SchoolSystem.Abstractions.Exceptions.Attributes;
using SchoolSystem.Abstractions.Exceptions.Base;

namespace SchoolSystem.Abstractions.Exceptions.Authorization
{
    public class AccessTokenLifetimeMismatchException : SchoolSystemException
    {
        public AccessTokenLifetimeMismatchException(long expectedTicks, long receivedTicks)
        {
            ExpectedTicks = expectedTicks;
            ReceivedTicks = receivedTicks;
        }

        [Log]
        public long ReceivedTicks { get; }
        [Log]
        public long ExpectedTicks { get; }
    }
}