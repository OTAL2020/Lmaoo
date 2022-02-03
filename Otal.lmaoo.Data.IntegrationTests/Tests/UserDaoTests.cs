using Microsoft.Extensions.Configuration;
using Otal.lmaoo.Data.DataAccessObjects;
using System;
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
        public void User_GetUserByUserId()
        {
            var user = _userDao.GetById(1);

            Assert.NotNull(user);
            Assert.Equal(1, user.UserId);
        }
    }
}