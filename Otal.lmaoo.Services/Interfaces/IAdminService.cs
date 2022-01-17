namespace Otal.lmaoo.Services.Interfaces
{
    using Otal.lmaoo.Core.Entities;

    public interface IAdminService
    {
        User GetByActive(bool isActive);

        User UpdateUser(User user);
    }
}