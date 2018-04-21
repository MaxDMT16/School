using Microsoft.Extensions.Configuration;

namespace SchoolSystem.WebApi.Configuration
{
    public abstract class AbstractConfiguration
    {
        protected AbstractConfiguration(IConfigurationRoot root)
        {
            var configurationSection = root.GetSection(GetType().Name);
            configurationSection.Bind(this);
        }
    }
}