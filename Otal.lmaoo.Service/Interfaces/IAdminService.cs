namespace Otal.lmaoo.Service.Interfaces
{
    using Otal.lmaoo.Core.Entities;

    public interface IAdminService
    {
        User GetByActive(bool isActive);

        User UpdateUser(User user);
    }
}