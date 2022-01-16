namespace Otal.lmaoo.Services.ServiceObjects
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using Otal.lmaoo.Services.Interfaces;

    public class AdminService : IAdminService
    {
        protected readonly IUserDao _userDao;

        public AdminService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public User GetByActive(bool IsActive)
        {
            return _userDao.GetByActive(IsActive);
        }

        public User UpdateUser(User user)
        {
            return _userDao.Update(user);
        }

        public User EditUser(User user)
        {
            return _userDao.Update(user);
        }
    }
}