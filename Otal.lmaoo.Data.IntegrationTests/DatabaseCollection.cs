namespace Otal.lmaoo.Data.IntegrationTests
{
    using Xunit;

    [CollectionDefinition("Database Collection")]
    public class DatabaseCollection : IClassFixture<DatabaseFixture>
    {
    }
}
