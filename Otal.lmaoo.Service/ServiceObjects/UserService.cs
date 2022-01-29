namespace Otal.lmaoo.Service.ServiceObjects
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using Otal.lmaoo.Service.Interfaces;

    public class UserService : IUserService
    {
        protected readonly IUserDao _userDao;

        public UserService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public User GetById(int userId)
        {
            return _userDao.GetById(userId);
        }

        public User GetByUsername(string username)
        {
            return _userDao.GetByUsername(username);
        }

        public (User, string message) GetByUsernameAndPassword(string username, string password)
        {
            var user = _userDao.GetByUsername(username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return (null, "Username and Password does not match");
            }

            if (!user.IsActive)
            {
                return (null, "User is no longer active, please contact the administrator");
            }

            return (user, null);
        }

        public User RegisterUser(User user)
        {
            return _userDao.Create(user);
        }
    }
}