using System;
using System.Data.SqlClient;
using Xunit.Abstractions;

namespace Otal.lmaoo.Data.IntegrationTests
{
    public static class DatabaseHelper
    {
        public static bool CheckDatabaseExists(string databaseName)
        {
            using (var connection = new SqlConnection(Database.MasterConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }

        public static int RunQuery(string query)
        {
            using (var connection = new SqlConnection(Database.ConnectionString()))
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