namespace Otal.lmaoo.Services.ServiceObjects
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using Otal.lmaoo.Services.Interfaces;
    public class AdminService : IAdminService
    {
        protected readonly IUsersDao _userDao;

        public AdminService(IUsersDao userDao)
        {
            _userDao = userDao;
        }

        public User GetByActive(int IsActive)
        {
            return _userDao.GetByActive(IsActive);
        }

        public User UpdateUser(string Username, string Forename, string Surname, int Level, int IsActive)
        {
            return _userDao.UpdateUser(Username, Forename, Surname, Level, IsActive);
        }

        public User DeactivateUser(int IsActive)
        {
            IsActive = 0;
            return _userDao.DeactivateUser(IsActive);
        }
    }
}
