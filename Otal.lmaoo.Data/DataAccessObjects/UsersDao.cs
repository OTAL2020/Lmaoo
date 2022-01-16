namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using System.Data;
    using System.Linq;

    public class UsersDao : DaoBase, IUsersDao
    {
        private new static IConfiguration _configuration;

        public UsersDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
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

        public User GetByActive(int IsActive)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_GetByActive]", new { Active = IsActive },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public void RegisterUser(User user)
        {
            using (var con = NewSqlConnection)
            {
                con.Query<User>("[dbo].[User_Register]", new
                {
                    Forename = user.Forename,
                    Surname = user.Surname,
                    Username = user.Username,
                    Password = user.Password
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public User UpdateUser(User user)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_UpdateUser]", new
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Forename = user.Forename,
                    Surname = user.Surname,
                    Level = user.Level,
                    IsActive = user.IsActive
                }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public User EditUserActiveStatus(int userId, int isActive)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_EditUserActiveStatus]", new { userId, isActive },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}