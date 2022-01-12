namespace Otal.lmaoo.Services.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    public interface IAdminService
    {
        User GetByActive(int isActive);

        User UpdateUser(User user);

        User EditUserActiveStatus(int userId, int Active);
    }
}
