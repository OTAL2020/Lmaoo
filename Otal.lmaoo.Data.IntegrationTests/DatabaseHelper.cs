namespace Otal.lmaoo.Data.IntegrationTests
{
    using System.Data.SqlClient;

    public static class DatabaseHelper
    {
        public static bool CheckDatabaseIsUp(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
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