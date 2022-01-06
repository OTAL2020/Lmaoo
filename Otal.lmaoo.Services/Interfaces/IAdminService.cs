namespace Otal.lmaoo.Services.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    public interface IAdminService
    {
        User GetByIsActive(int id);

        User UpdateUser(string Username, string Forename, string Surname, int Level, bool IsActive);

        User DeactivateUser(bool IsActive);
    }
}
