using System;
using Microsoft.Extensions.Configuration;
using SchoolSystem.Abstractions.Configuration;

namespace SchoolSystem.WebApi.Configuration
{
    public class AccessTokenConfiguration : AbstractConfiguration, IAccessTokenConfiguration
    {
        public AccessTokenConfiguration(IConfigurationRoot root) : base(root)
        {
        }

        public TimeSpan LifeTime { get; set; }
        public string ServerKey { get; set; }
    }
}