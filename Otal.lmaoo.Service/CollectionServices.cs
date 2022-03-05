namespace Otal.lmaoo.Service
{
    using Microsoft.Extensions.DependencyInjection;
    using Otal.lmaoo.Service.Interfaces;
    using Otal.lmaoo.Service.ServiceObjects;

    public static class CollectionServices
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAdminService, AdminService>();
            service.AddScoped<ICommentService, CommentService>();
        }
    }
}