using Microsoft.Extensions.Configuration;
using System.IO;

namespace RDV.Helpers
{
    public static class AppSettingsJson
    {
        public static IConfigurationSection GetConfig(string key)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            var configurationSection = configuration.GetSection(key);
            return configurationSection;
        }
    }
}
