namespace Otal.lmaoo.Data
{
    using Microsoft.Extensions.DependencyInjection;
    using Otal.lmaoo.Data.DataAccessObjects;
    using Otal.lmaoo.Data.Interfaces;

    public static class CollectionData
    {
        public static void RegisterDaos(IServiceCollection service)
        {
            service.AddScoped<IUserDao, UserDao>();
        }
    }
}