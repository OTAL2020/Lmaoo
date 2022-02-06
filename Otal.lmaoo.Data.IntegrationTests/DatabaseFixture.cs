namespace Otal.lmaoo.Data.IntegrationTests
{
    using Otal.lmaoo.Data.IntegrationTests.Seed;
    using System;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;

    public class DatabaseFixture
    {
        public DatabaseFixture()
        {
            if (!DatabaseHelper.CheckDatabaseIsUp(Database.MasterConnectionString()))
            {
                throw new Exception($"Database Connection not successful, Aborting Data Integration Tests Debug: {Database.SOURCE} {Database.PORT} {Database.USERNAME}");
            }

            Console.WriteLine($"Running Powershell Script");
            var file = File.ReadAllText(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Otal.lmaoo.Database_Create.sql");
            //var dir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Otal.lmaoo.Database_Create.sql";
            var dir = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "setupdatabase.ps1";
            PowerShell ps = PowerShell
                                .Create()
                                .AddCommand(dir)
                                .AddParameter("SQLServer", Database.SOURCE);
                                //.AddScript(dir);

            var results = ps.Invoke();


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