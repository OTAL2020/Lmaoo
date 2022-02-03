namespace Otal.lmaoo.Service.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using System.Collections.Generic;

    public interface IAdminService
    {
        IEnumerable<User> GetByActive(bool isActive);

        User UpdateUser(User user);
    }
}