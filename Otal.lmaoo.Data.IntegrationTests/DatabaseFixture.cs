namespace Otal.lmaoo.Data.IntegrationTests
{
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Data.IntegrationTests.Seed;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Xunit;
    using Xunit.Abstractions;

    public class DatabaseFixture
    {
        public string connectionString;

        public DatabaseFixture()
        {
            if (!DatabaseHelper.CheckDatabaseExists("Otal.lmaoo.Database"))
            {
                throw new Exception("Connection Successful, Database not found... Aborting Data Integration Tests");
            }

            connectionString = Database.ConnectionString();

            var seeds = AppDomain.CurrentDomain
                                .GetAssemblies()
                                .SelectMany(x => x.GetTypes())
                                .Where(x => typeof(ISeed).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                                .Select(x =>
                                {
                                    return Activator.CreateInstance(x);
                                })
                                .Cast<ISeed>()
                                .OrderBy(x => x.OrderNumber);

            foreach (ISeed seed in seeds)
            {
                int rowseffected = DatabaseHelper.RunQuery(seed.GetAllData());
                Console.WriteLine($"{seed.DataType} Added: {rowseffected}");
            }
        }
    }
}