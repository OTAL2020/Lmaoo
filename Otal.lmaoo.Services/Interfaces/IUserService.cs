using Otal.lmaoo.Core.Entities;

namespace Otal.lmaoo.Services.Interfaces
{
    public interface IUserService
    {
        User Get(int id);

        User GetByUsername(string username);

        User GetByUsernameAndPassword(string username, string password);

        void RegisterUser(User user);
    }
}
