namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;

    public interface IUserDao
    {
        User GetById(int id);

        User GetByUsername(string username);

        User GetByActive(int isActive);

        User EditUserActiveStatus(int id, int IsActive);

        void RegisterUser(User user);
        User UpdateUser(User user);
    }
}