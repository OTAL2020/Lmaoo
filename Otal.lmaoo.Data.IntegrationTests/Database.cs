using System;
using System.Data.SqlClient;
using Xunit.Abstractions;

namespace Otal.lmaoo.Data.IntegrationTests
{
    public static class Database
    {
        public static string ConnectionString()
        {
            var db_db = Environment.GetEnvironmentVariable("DB_DATABASE");
            var db_pass = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var connectionString = string.Format("Data Source=db;Database={0};User Id=sa;Password={1};", db_db, db_pass);

            return connectionString;
        }

        public static bool CheckDatabaseExists(string connectionString, string databaseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }

        public static int RunQuery(string connectionString, string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand($"{query}", connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}