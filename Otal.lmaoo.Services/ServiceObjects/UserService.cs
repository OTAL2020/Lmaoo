namespace Otal.lmaoo.Services.ServiceObjects
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using Otal.lmaoo.Services.Interfaces;

    public class UserService : IUserService
    {
        protected readonly IUsersDao _userDao;

        public UserService(IUsersDao userDao)
        {
            _userDao = userDao;
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return _userDao.GetByUsername(username);
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = _userDao.GetByUsername(username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }

            return user;
        }

        public void RegisterUser(User user)
        {
            _userDao.RegisterUser(user);
        }
    }
}