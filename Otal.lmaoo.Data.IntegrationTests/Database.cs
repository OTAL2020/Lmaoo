namespace Otal.lmaoo.Data.IntegrationTests
{
    using System;

    public static class Database
    {
        public static string SOURCE => Environment.GetEnvironmentVariable("DB_SOURCE") ?? "localhost";
        public static string PORT => Environment.GetEnvironmentVariable("DB_PORT") ?? "1433";
        public static string NAME => Environment.GetEnvironmentVariable("DB_NAME") ?? "Otal.lmaoo.Database";
        public static string USERNAME => Environment.GetEnvironmentVariable("DB_USERNAME") ?? "sa";
        public static string PASSWORD => Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "IntegrationTest123!";
        public static string ConnectionString()
        {
            string cs = string.Format("Data Source={0},{1};Database={2};User Id={3};Password={4};",
                        SOURCE,
                        PORT,
                        NAME,
                        USERNAME,
                        PASSWORD);

            return cs;
        }

        public static string MasterConnectionString()
        {
            string cs = string.Format("Data Source={0},{1};Database={2};User Id={3};Password={4};",
                        SOURCE,
                        PORT,
                        "master",
                        USERNAME,
                        PASSWORD);

            return cs;
        }
    }
}