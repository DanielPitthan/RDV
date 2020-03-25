using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContextBinds
{
    public static class ConecxaoAtiva
    {
        public static string StringConnection()
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();
            var conecxaoAtiva = configuration.GetSection("ConecxaoAtiva");

            return configuration.GetConnectionString(conecxaoAtiva.Value);
        }
    }
}
