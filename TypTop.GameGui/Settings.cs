using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TypTop.GameGui
{
    public class Settings
    {
        public static Settings Instance => LazySettings.Value;

        private static readonly Lazy<Settings> LazySettings = new Lazy<Settings>(() =>
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) ||
                                devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                    optional: false,
                    reloadOnChange: true)
                .AddUserSecrets<MainWindow>();
            IConfigurationRoot configurationRoot = builder.Build();
            return new Settings(configurationRoot);
        });

        private readonly IConfigurationRoot _configurationRoot;

        private Settings(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string DatabaseConnectionString =>
            _configurationRoot.GetSection("Database").GetValue<string>("ConnectionString");
    }
}