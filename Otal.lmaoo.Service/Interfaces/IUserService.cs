namespace Otal.lmaoo.Service.Interfaces
{
    using Otal.lmaoo.Core.Entities;

    public interface IUserService
    {
        User GetById(int id);

        User GetByUsername(string username);

        (User, string message) GetByUsernameAndPassword(string username, string password);

        User RegisterUser(User user);
    }
}