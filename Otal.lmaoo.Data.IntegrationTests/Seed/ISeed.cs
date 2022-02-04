namespace Otal.lmaoo.Data.IntegrationTests.Seed
{
    public interface ISeed
    {
        int OrderNumber();

        string DataType();

        string GetAllData();
    }
}