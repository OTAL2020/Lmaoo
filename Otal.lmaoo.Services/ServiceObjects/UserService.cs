namespace Otal.lmaoo.Services.ServiceObjects
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using Otal.lmaoo.Services.Interfaces;

    public class UserService : IUserService
    {
        protected readonly IUsersDao _dao;

        public UserService(IUsersDao dao)
        {
            _dao = dao;
        }

        public User Get(int id)
        {
            return _dao.Get(id);
        }

        public User GetByUsername(string username)
        {
            return _dao.GetByUsername(username);
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = _dao.GetByUsername(username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }

            return user;
        }
        public void RegisterUser(User user)
        {
            _dao.RegisterUser(user);
        }
    }
}