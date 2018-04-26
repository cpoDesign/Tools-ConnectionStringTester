namespace Tester.Tester
{
    using System;
    using Dapper;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Data access
    /// </summary>
    public class DataAccessTester
    {
        private const string ConnectionStringInformation = "ConnectionStringUnderTest";
        private const string CommandTimeOut = "CommandTimeOut";
        private const string SqlCommand = "SqlCommand";

        /// <summary>
        /// Checks database connectivity
        /// </summary>
        /// <returns>boolean result of the success</returns>
        public bool CheckDatabaseConnectivity()
        {
            string connectionString = string.Empty;
            int timeout = 0;
            string testCommand = string.Empty;

            try
            {
                connectionString = ConfigurationLoader.LoadConnectionString(ConnectionStringInformation);

                int.TryParse(ConfigurationLoader.GetAppConfigValue(CommandTimeOut), out timeout);

                testCommand = ConfigurationLoader.GetAppConfigValue(SqlCommand);
            }
            catch(Exception ex)
            {
                ConsoleLogger.Info($"Faied to load configuration from app.settings file.{ex.Message} ");
            }

            ConsoleLogger.RenderSeparator(100, "=");
            ConsoleLogger.HighLight($"Using connection string: {connectionString}");
            ConsoleLogger.HighLight($"Command timeout: {timeout}");
            ConsoleLogger.HighLight($"SQL command: {testCommand}");
            ConsoleLogger.RenderSeparator(100, "=");

            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    var result = connection.QuerySingleOrDefault<int>(sql: testCommand, commandTimeout: timeout);

                    return result == 1;
                }
            }
            catch (Exception ex)
            {
                ConsoleLogger.Info($"Exception has been thrown: {ex.Message} {ex.StackTrace.ToString()}");
                return false;
            }
        }
    }
}
