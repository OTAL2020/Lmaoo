namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;

    public interface IUserDao : IDaoBase<User>
    {
        User GetByUsername(string username);

        User GetByActive(int isActive);
    }
}