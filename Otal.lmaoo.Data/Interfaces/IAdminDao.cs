namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;

    public interface IAdminDao
    {
        User GetByIsActive(int id);

        User UpdateUser(string Username, string Forename, string Surname, int Level, bool IsActive);

        User DeactivateUser(bool IsActive);
    }
}
