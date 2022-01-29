namespace Otal.lmaoo.Data.IntegrationTests.Seed
{
    public interface ISeed
    {
        string DataType();

        string GetAllData();
    }
}