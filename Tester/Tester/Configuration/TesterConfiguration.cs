using System.Configuration;

namespace Tester.Tester
{
    internal class ConfigurationLoader
    {
        /// <summary>
        /// Loads the connection string from application configuration.
        /// </summary>
        /// <param name="connectionstringName">Name of the connectionstring to use for testing.</param>
        /// <returns>Connection string if provided</returns>
        /// <exception cref="ConfigurationErrorsException">Can be throw when there is no connection string with defined name.</exception>
        public static string LoadConnectionString(string connectionstringName = "ConnectionStringUnderTest")
        {
            var config = ConfigurationManager.ConnectionStrings[connectionstringName];
            if (config == null)
            {
                ConsoleLogger.Info($"Failed to find config {connectionstringName}");
                throw new ConfigurationErrorsException($"Failed to find {connectionstringName}");
            }

            return config.ConnectionString;
        }

        /// <summary>
        /// Gets value from app settings.
        /// </summary>
        /// <param name="configurationValue">Name of application setting</param>
        /// <returns>Timeout value</returns>
        /// <exception cref="ConfigurationErrorsException">Throws if configuration is missing</exception>
        public static string GetAppConfigValue(string configurationValue)
        {
            var value = ConfigurationManager.AppSettings[configurationValue];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"Failed to find application setting: {configurationValue} in your app.config.");
            }

            return value;
        }
    }
}