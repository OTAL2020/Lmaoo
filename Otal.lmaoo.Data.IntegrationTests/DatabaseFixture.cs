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
            connectionString = Database.ConnectionString();
            bool checker = false;
            int i = 0;

            while (i <= 5)
            {
                if (!Database.CheckDatabaseExists(connectionString, "Otal.lmaoo.Database"))
                {
                    Console.WriteLine($"Waiting for Database to exist... Try {i}");
                    Thread.Sleep(5000);
                    i++;
                }
                else
                {
                    checker = true;
                    break;
                }
            }

            if (i == 5 && !checker)
            {
                Console.WriteLine($"Database does not exist after 25 seconds, stopping integration tests. Debug -> {connectionString}");
            }

            var seeds = AppDomain.CurrentDomain
                                .GetAssemblies()
                                .SelectMany(x => x.GetTypes())
                                .Where(x => typeof(ISeed).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                                .Select(x =>
                                {
                                    return Activator.CreateInstance(x);
                                })
                                .Cast<ISeed>();

            foreach (ISeed seed in seeds)
            {
                int rowseffected = Database.RunQuery(connectionString, seed.GetAllData());
                Console.WriteLine($"{seed.DataType()} Added: {rowseffected}");
            }
        }
    }
}