namespace Otal.lmaoo.Data.IntegrationTests
{
    using Otal.lmaoo.Data.IntegrationTests.Seed;
    using System;
    using System.Linq;

    public class DatabaseFixture
    {
        public DatabaseFixture()
        {
            if (!DatabaseHelper.CheckDatabaseIsUp(Database.MasterConnectionString()))
            {
                throw new Exception($"Database Connection not successful, Aborting Data Integration Tests Debug: {Database.SOURCE} {Database.PORT} {Database.USERNAME}");
            }

            var seeds = AppDomain.CurrentDomain
                            .GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => typeof(ISeed).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                            .Select(x =>
                            {
                                return Activator.CreateInstance(x);
                            })
                            .Cast<ISeed>()
                            .OrderBy(x => x.OrderNumber());

            foreach (ISeed seed in seeds)
            {
                int rowseffected = DatabaseHelper.RunQuery(seed.GetAllData());
                Console.WriteLine($"{seed.DataType()} Added: {rowseffected}");
            }
        }
    }
}