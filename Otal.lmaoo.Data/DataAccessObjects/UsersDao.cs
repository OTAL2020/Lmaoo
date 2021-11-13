namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using System;
    using System.Data;
    using System.Linq;

    public class UsersDao : DaoBase, IUsersDao
    {
        private static new IConfiguration _configuration;
        public UsersDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public User Get(int id)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_GetById]", new { UserId = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public User GetByUsername(string username)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_GetByUsername]", new { Username = username }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}