namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;

    public interface IUsersDao
    {
        User Get(int id);

        User GetByUsername(string username);
    }
}