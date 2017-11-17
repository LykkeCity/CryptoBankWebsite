using Microsoft.Extensions.Configuration;
using System.IO;

namespace ModernWallet
{
    public static class ApplicationSettings
    {
        public static IConfigurationRoot Configuration { get; set; }

        static ApplicationSettings()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }
    }
}
