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

        public User GetByActive(int IsActive)
        {
            return _userDao.GetByActive(IsActive);
        }

        public User UpdateUser(User user)
        {
            return _userDao.UpdateUser(user);
        }

        public User EditUserActiveStatus(int userId, int active)
        {
            return _userDao.EditUserActiveStatus(userId, active);
        }
    }
}
