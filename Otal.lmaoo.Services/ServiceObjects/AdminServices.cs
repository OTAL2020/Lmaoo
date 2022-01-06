namespace Otal.lmaoo.Services.ServiceObjects
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using Otal.lmaoo.Services.Interfaces;
    public class AdminService : IAdminService
    {
        protected readonly IAdminDao _dao;

        public AdminService(IAdminDao dao)
        {
            _dao = dao;
        }

        public User GetByIsActive(int IsActive)
        {
            return _dao.GetByIsActive(IsActive);
        }

        public User UpdateUser(string Username, string Forename, string Surname, int Level, bool IsActive)
        {
            return _dao.UpdateUser(Username,Forename,Surname,Level,IsActive);
        }

        public User DeactivateUser(bool IsActive)
        {
            IsActive = false;
            return _dao.DeactivateUser(IsActive);
        }
    }
}
