using Microsoft.Extensions.Configuration;
using Otal.lmaoo.Core.Entities;
using Otal.lmaoo.Core.Enums;
using Otal.lmaoo.Data.DataAccessObjects;
using Otal.lmaoo.Data.IntegrationTests.Seed;
using System.IO;
using Xunit;

namespace Otal.lmaoo.Data.IntegrationTests.Tests
{
    public class UserDaoTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly IConfiguration _configuration;
        private readonly UserDao _userDao;

        public UserDaoTests(DatabaseFixture fixture)
        {
            _databaseFixture = fixture;

            _configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(
                path: "appsettings.json",
                optional: false,
                reloadOnChange: true)
           .Build();

            _configuration["DB_SOURCE"] = Database.SOURCE;
            _configuration["DB_PORT"] = Database.PORT;
            _configuration["DB_DATABASE"] = Database.NAME;
            _configuration["DB_PASSWORD"] = Database.PASSWORD;

            _userDao = new UserDao(_configuration);
        }

        [Fact]
        public void GetById_ValidUser()
        {
            var user = _userDao.GetById(1);

            Assert.NotNull(user);
            Assert.Equal(1, user.UserId);
            Assert.Equal(UserSeed.DeveloperUser.Forename, user.Forename);
            Assert.Equal(UserSeed.DeveloperUser.Surname, user.Surname);
            Assert.Equal(UserSeed.DeveloperUser.Username, user.Username);
            Assert.NotNull(user.Password);
            Assert.Equal(UserSeed.DeveloperUser.Level, user.Level);
            Assert.Equal(UserSeed.DeveloperUser.IsActive, user.IsActive);
        }

        [Fact]
        public void GetById_InvalidUser()
        {
            var user = _userDao.GetById(1000);
            Assert.Null(user);
        }

        [Fact]
        public void GetByUsername_ValidUsername()
        {
            var user = _userDao.GetByUsername(UserSeed.ManagerUser.Username);

            Assert.NotNull(user);
            Assert.Equal(UserSeed.ManagerUser.Username, user.Username);
            Assert.Equal(UserSeed.ManagerUser.Forename, user.Forename);
            Assert.Equal(UserSeed.ManagerUser.Surname, user.Surname);
            Assert.NotNull(user.Password);
            Assert.Equal(UserSeed.ManagerUser.Level.ToString(), user.Level.ToString());
            Assert.Equal(UserSeed.ManagerUser.IsActive.ToString(), user.IsActive.ToString());
        }

        [Fact]
        public void GetByUsername_InvalidUser()
        {
            var user = _userDao.GetByUsername("ThisUsernameDoesNotExist");
            Assert.Null(user);
        }

        [Fact]
        public void GetByActive_True()
        {
            var users = _userDao.GetByActive(true);
            Assert.NotNull(users);

            foreach (var user in users)
            {
                Assert.True(user.IsActive);
            }
        }

        [Fact]
        public void GetByActive_False()
        {
            var users = _userDao.GetByActive(false);
            Assert.NotNull(users);

            foreach (var user in users)
            {
                Assert.False(user.IsActive);
            }
        }

        [Fact]
        public void Update_ValidUser()
        {
            var updatedUser = new User
            {
                UserId = UserSeed.SuperAdminUser.UserId,
                Username = "New Username",
                Forename = "New Forename",
                Surname = "New Surname",
                Level = UserRole.SuperAdmin,
                IsActive = false,
            };

            var actualUser = _userDao.Update(updatedUser);

            Assert.NotNull(actualUser);
            Assert.Equal(updatedUser.UserId, actualUser.UserId);
            Assert.Equal(updatedUser.Username, actualUser.Username);
            Assert.Equal(updatedUser.Forename, actualUser.Forename);
            Assert.Equal(updatedUser.Surname, actualUser.Surname);
            Assert.Equal(updatedUser.Level, actualUser.Level);
            Assert.Equal(updatedUser.IsActive, actualUser.IsActive);
        }

        [Fact]
        public void Create_ValidUser()
        {
            var newUser = new User
            {
                Forename = "New",
                Surname = "User",
                Username = "NewUser",
                Password = "pass"
            };

            var actualUser = _userDao.Create(newUser);

            Assert.NotNull(actualUser);
            Assert.Equal(newUser.Forename, actualUser.Forename);
            Assert.Equal(newUser.Surname, actualUser.Surname);
            Assert.Equal(newUser.Username, actualUser.Username);
            Assert.Equal(newUser.Password, actualUser.Password);
        }

        [Fact]
        public void Delete_ValidUser()
        {
            _userDao.Delete(UserSeed.AdminUser.UserId);
            var user = _userDao.GetById(UserSeed.AdminUser.UserId);
            Assert.False(user.IsActive);
        }
    }
}