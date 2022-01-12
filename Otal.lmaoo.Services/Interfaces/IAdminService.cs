namespace Otal.lmaoo.Services.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    public interface IAdminService
    {
        User GetByActive(int isActive);

        User UpdateUser(string Username, string Forename, string Surname, int Level, int IsActive);

        User EditUserActiveStatus(int userId, int Active);
    }
}
