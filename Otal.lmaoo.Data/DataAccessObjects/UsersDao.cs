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
                return con.Query<User>("[dbo].[User_GetById]", new { UserId = id }, 
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
                    Username =  user.Username,
                    Password = user.Password
                }, commandType: CommandType.StoredProcedure);
            }
        }

        public User UpdateUser(string Username, string Forename, string Surname, int Level, int IsActive)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_UpdateUser]", new { Username, Forename, Surname, Level, IsActive }, 
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public User DeactivateUser(int IsActive)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<User>("[dbo].[User_DeactivateUser]", new { IsActive }, 
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}