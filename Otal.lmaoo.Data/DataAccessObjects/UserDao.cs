namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.DataAccessObjects.Base;
    using Otal.lmaoo.Data.Interfaces;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class UserDao : DaoBase, IUserDao
    {
        public UserDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public User Create(User user)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_Create]", new
                {
                    Forename = user.Forename,
                    Surname = user.Surname,
                    Username = user.Username,
                    Password = user.Password
                }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public User GetById(int userId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_GetById]", new { UserId = userId },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public User GetByUsername(string username)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_GetByUsername]", new { Username = username },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public IEnumerable<User> GetByActive(bool IsActive)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_GetByActive]", new { IsActive },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public User Update(User user)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_Update]", new
                {
                    Username = user.Username,
                    Forename = user.Forename,
                    Surname = user.Surname,
                    Level = user.Level,
                    IsActive = user.IsActive,
                    UserId = user.UserId,
                }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public void Delete(int userId)
        {
            using (var con = NewSqlConnection)
            {
                con.Execute("[dbo].[User_Delete]", new { userId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}