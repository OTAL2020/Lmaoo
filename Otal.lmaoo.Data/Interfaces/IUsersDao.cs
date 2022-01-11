namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;

    public interface IUsersDao
    {
        User Get(int id);

        User GetByUsername(string username);

        User GetByActive(int isActive);

        User UpdateUser(string Username, string Forename, string Surname, int Level, int IsActive);

        User DeactivateUser(int IsActive);

        void RegisterUser(User user);
    }
}