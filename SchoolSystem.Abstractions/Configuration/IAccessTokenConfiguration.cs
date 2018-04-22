using System;

namespace SchoolSystem.Abstractions.Configuration
{
    public interface IAccessTokenConfiguration
    {
        TimeSpan LifeTime { get; }
        string ServerKey { get; }
    }
}