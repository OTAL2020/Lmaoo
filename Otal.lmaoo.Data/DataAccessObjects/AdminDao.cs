namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using System.Data;
    using System.Linq;

    public class AdminDao : DaoBase, IAdminDao
    {
        private static new IConfiguration _configuration;
        public AdminDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public User GetByIsActive(int IsActive)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_GetByActive]", new { IsActive }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public User UpdateUser(string Username, string Forename, string Surname, int Level, bool IsActive)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_UpdateUser]", new { Username, Forename, Surname, Level, IsActive }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public User DeactivateUser(bool IsActive)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_DeactivateUser]", new { IsActive }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}
