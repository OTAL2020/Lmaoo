namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces.Base;

    public interface IUserDao : IDaoBase<User>
    {
        User GetByUsername(string username);

        User GetByActive(bool isActive);
    }
}