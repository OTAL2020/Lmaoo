namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces.Base;
    using System.Collections.Generic;

    public interface IUserDao : IDaoBase<User>
    {
        User GetByUsername(string username);

        IEnumerable<User> GetByActive(bool isActive);
    }
}