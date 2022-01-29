using Otal.lmaoo.Core.Entities;

namespace Otal.lmaoo.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);

        User GetByUsername(string username);

        (User, string errorMessage) GetByUsernameAndPassword(string username, string password);

        void RegisterUser(User user);
    }
}
