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
    }
}