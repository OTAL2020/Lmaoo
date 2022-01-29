namespace Otal.lmaoo.Service.UnitTests
{
    using NSubstitute;
    using NSubstitute.ReturnsExtensions;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using Otal.lmaoo.Service.ServiceObjects;
    using System;
    using Xunit;

    public class UserServiceTests
    {
        private readonly UserService _sut;
        private readonly IUserDao _userDao = Substitute.For<IUserDao>();

        public UserServiceTests()
        {
            _sut = new UserService(_userDao);
        }

        [Fact]
        public void GetById_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var expectedUser = new User
            {
                UserId = 1,
                Forename = "Unit",
                Surname = "Test",
                Username = "user",
                Password = "pass",
                IsActive = true,
                Level = Core.Enums.UserRole.Developer
            };

            _userDao.GetById(expectedUser.UserId).Returns(expectedUser);

            // Act
            var actualUser = _sut.GetById(expectedUser.UserId);

            // Assert
            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.Forename, actualUser.Forename);
            Assert.Equal(expectedUser.Surname, actualUser.Surname);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Password, actualUser.Password);
            Assert.Equal(expectedUser.IsActive, actualUser.IsActive);
            Assert.Equal(expectedUser.Level, actualUser.Level);
        }

        [Fact]
        public void GetById_ShouldNotReturnUser_WhenUserDoesNotExist()
        {
            // Arrange
            var randomUserId = new Random().Next(10);
            _userDao.GetById(randomUserId).ReturnsNull();

            // Act
            var actualUser = _sut.GetById(randomUserId);

            // Assert
            Assert.Null(actualUser);
        }

        [Fact]
        public void GetByUsername_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var expectedUser = new User
            {
                UserId = 1,
                Forename = "Unit",
                Surname = "Test",
                Username = "user",
                Password = "pass",
                IsActive = true,
                Level = Core.Enums.UserRole.Developer
            };

            _userDao.GetByUsername(expectedUser.Username).Returns(expectedUser);

            // Act
            var actualUser = _sut.GetByUsername(expectedUser.Username);

            // Assert
            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.Forename, actualUser.Forename);
            Assert.Equal(expectedUser.Surname, actualUser.Surname);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Password, actualUser.Password);
            Assert.Equal(expectedUser.IsActive, actualUser.IsActive);
            Assert.Equal(expectedUser.Level, actualUser.Level);
        }

        [Fact]
        public void GetByUsername_ShouldNotReturnUser_WhenUserDoesNotExist()
        {
            // Arrange
            var randomUsername = "RandomUsername";
            _userDao.GetByUsername(randomUsername).ReturnsNull();

            // Act
            var actualUser = _sut.GetByUsername(randomUsername);

            // Assert
            Assert.Null(actualUser);
        }

        [Fact]
        public void GetByUsernameAndPassword_ShouldReturnUser_PasswordDoesMatch()
        {
            // Arrange
            var password = "pass";
            var expectedUser = new User
            {
                UserId = 1,
                Forename = "Unit",
                Surname = "Test",
                Username = "user",
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                IsActive = true,
                Level = Core.Enums.UserRole.Developer
            };

            _userDao.GetByUsername(expectedUser.Username).Returns(expectedUser);

            // Act
            (var actualUser, var message) = _sut.GetByUsernameAndPassword(expectedUser.Username, password);

            // Assert
            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.Forename, actualUser.Forename);
            Assert.Equal(expectedUser.Surname, actualUser.Surname);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Password, actualUser.Password);
            Assert.Equal(expectedUser.IsActive, actualUser.IsActive);
            Assert.Equal(expectedUser.Level, actualUser.Level);
            Assert.Null(message);
        }

        [Fact]
        public void GetByUsernameAndPassword_ShouldReturnUser_PasswordDoesNotMatch()
        {
            // Arrange
            var password = "pass";
            var expectedUser = new User
            {
                UserId = 1,
                Forename = "Unit",
                Surname = "Test",
                Username = "user",
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                IsActive = true,
                Level = Core.Enums.UserRole.Developer
            };

            _userDao.GetByUsername(expectedUser.Username).Returns(expectedUser);

            // Act
            (var actualUser, var message) = _sut.GetByUsernameAndPassword(expectedUser.Username, "WrongPassword");

            // Assert
            Assert.Null(actualUser);
            Assert.NotNull(message);
            Assert.Equal("Username and Password does not match", message);
        }

        [Fact]
        public void GetByUsernameAndPassword_ShouldReturnUser_UserNotActive()
        {
            // Arrange
            var password = "pass";
            var expectedUser = new User
            {
                UserId = 1,
                Forename = "Unit",
                Surname = "Test",
                Username = "user",
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                IsActive = false,
                Level = Core.Enums.UserRole.Developer
            };

            _userDao.GetByUsername(expectedUser.Username).Returns(expectedUser);

            // Act
            (var actualUser, var message) = _sut.GetByUsernameAndPassword(expectedUser.Username, password);

            // Assert
            Assert.Null(actualUser);
            Assert.NotNull(message);
            Assert.Equal("User is no longer active, please contact the administrator", message);
        }

        [Fact]
        public void RegisterUser_ShouldReturnUser()
        {
            // Arrange
            var expectedUser = new User
            {
                UserId = 1,
                Forename = "Unit",
                Surname = "Test",
                Username = "user",
                Password = "pass",
                IsActive = true,
                Level = Core.Enums.UserRole.Developer
            };

            _userDao.Create(expectedUser).Returns(expectedUser);

            // Act
            var actualUser = _sut.RegisterUser(expectedUser);

            // Assert
            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser.Forename, actualUser.Forename);
            Assert.Equal(expectedUser.Surname, actualUser.Surname);
            Assert.Equal(expectedUser.Username, actualUser.Username);
            Assert.Equal(expectedUser.Password, actualUser.Password);
            Assert.Equal(expectedUser.IsActive, actualUser.IsActive);
            Assert.Equal(expectedUser.Level, actualUser.Level);
        }
    }
}