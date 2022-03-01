namespace Otal.lmaoo.Data.IntegrationTests.Tests
{
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.DataAccessObjects;
    using Otal.lmaoo.Data.IntegrationTests.Seed;
    using System.IO;
    using System.Linq;
    using Xunit;

    [Collection("Database Collection")]
    public class CommentDaoTests
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly IConfiguration _configuration;
        private readonly CommentDao _commentDao;

        public CommentDaoTests(DatabaseFixture fixture)
        {
            this._databaseFixture = fixture;

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

            _commentDao = new CommentDao(_configuration);
        }

        [Fact]
        public void Create_ValidComment()
        {
            var newComment = new Comment
            {
                Content = "New Comment",
                TicketId = TicketSeed.BackLogTicket.TicketId,
                UserId = UserSeed.DeveloperUser.UserId,
            };

            var actualComment = _commentDao.Create(newComment);

            Assert.Equal(newComment.Content, actualComment.Content);
            Assert.Equal(newComment.TicketId, actualComment.TicketId);
            Assert.Equal(newComment.UserId, actualComment.UserId);
            Assert.Equal(UserSeed.DeveloperUser.Forename, actualComment.Forename);
            Assert.Equal(UserSeed.DeveloperUser.Surname, actualComment.Surname);
            Assert.Equal(UserSeed.DEFAULT_PICTURE_URL, actualComment.Picture);
        }

        [Fact]
        public void GetById_ValidComment()
        {
            var actualComment = _commentDao.GetById(CommentSeed.BacklogComment.CommentId);

            Assert.Equal(CommentSeed.BacklogComment.Content, actualComment.Content);
            Assert.Equal(CommentSeed.BacklogComment.TicketId, actualComment.TicketId);
            Assert.Equal(CommentSeed.BacklogComment.UserId, actualComment.UserId);
            Assert.Equal(UserSeed.DeveloperUser.Forename, actualComment.Forename);
            Assert.Equal(UserSeed.DeveloperUser.Surname, actualComment.Surname);
            Assert.Equal(UserSeed.DEFAULT_PICTURE_URL, actualComment.Picture);
        }

        [Fact]
        public void GetByTicketId_ValidComment()
        {
            var actualComment = _commentDao.GetByTicketId(CommentSeed.BacklogComment.TicketId).First();

            Assert.Equal(CommentSeed.BacklogComment.Content, actualComment.Content);
            Assert.Equal(CommentSeed.BacklogComment.TicketId, actualComment.TicketId);
            Assert.Equal(CommentSeed.BacklogComment.UserId, actualComment.UserId);
            Assert.Equal(UserSeed.DeveloperUser.Forename, actualComment.Forename);
            Assert.Equal(UserSeed.DeveloperUser.Surname, actualComment.Surname);
            Assert.Equal(UserSeed.DEFAULT_PICTURE_URL, actualComment.Picture);
        }

        [Fact]
        public void Update_ValidComment()
        {
            var updateComment = new Comment
            {
                CommentId = CommentSeed.ToBeUpdatedComment.CommentId,
                Content = "This comment has now been updated",
                TicketId = TicketSeed.InDevTicket.TicketId,
                UserId = UserSeed.ManagerUser.UserId
            };

            var actualComment = _commentDao.Update(updateComment);

            Assert.Equal(updateComment.Content, actualComment.Content);
            Assert.Equal(updateComment.TicketId, actualComment.TicketId);
            Assert.Equal(updateComment.UserId, actualComment.UserId);
            Assert.Equal(UserSeed.ManagerUser.Forename, actualComment.Forename);
            Assert.Equal(UserSeed.ManagerUser.Surname, actualComment.Surname);
            Assert.Equal(UserSeed.DEFAULT_PICTURE_URL, actualComment.Picture);
        }

        [Fact]
        public void Delete_ValidComment()
        {
            _commentDao.Delete(CommentSeed.ToBeDeletedComment.CommentId);
            var deletedComment = _commentDao.GetById(CommentSeed.ToBeDeletedComment.CommentId);
            Assert.Null(deletedComment);
        }
    }
}