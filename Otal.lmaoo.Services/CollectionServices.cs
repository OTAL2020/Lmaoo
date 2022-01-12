namespace Otal.lmaoo.Services
{
    using Microsoft.Extensions.DependencyInjection;
    using Otal.lmaoo.Services.Interfaces;
    using Otal.lmaoo.Services.ServiceObjects;

    public static class CollectionServices
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAdminService, AdminService>();
        }
    }
}