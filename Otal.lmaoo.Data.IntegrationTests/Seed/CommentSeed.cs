namespace Otal.lmaoo.Data.IntegrationTests.Seed
{
    using Otal.lmaoo.Core.Entities;
    using SqlKata;
    using SqlKata.Compilers;

    public class CommentSeed : ISeed
    {
        public static Comment BacklogComment = new Comment
        {
            CommentId = 1,
            Content = "BacklogComment",
            TicketId = TicketSeed.BackLogTicket.TicketId,
            UserId = UserSeed.DeveloperUser.UserId
        };

        public static Comment ToBeUpdatedComment = new Comment
        {
            CommentId = 2,
            Content = "ToBeUpdatedComment",
            TicketId = TicketSeed.InDevTicket.TicketId,
            UserId = UserSeed.ManagerUser.UserId
        };

        public static Comment ToBeDeletedComment = new Comment
        {
            CommentId = 3,
            Content = "ToBeDeletedComment",
            TicketId = TicketSeed.InDevTicket.TicketId,
            UserId = UserSeed.ManagerUser.UserId
        };

        public string DataType() => "Comment";

        public int OrderNumber() => 5;

        public string GetAllData()
        {
            var query = new Query("dbo.Comment")
                .AsInsert(new string[]
                {
                    "Content", "TicketId", "UserId"
                },
                new[]
                {
                    new object[]
                    {
                        BacklogComment.Content,
                        BacklogComment.TicketId,
                        BacklogComment.UserId,
                    },
                    new object[]
                    {
                        ToBeUpdatedComment.Content,
                        ToBeUpdatedComment.TicketId,
                        ToBeUpdatedComment.UserId,
                    },
                    new object[]
                    {
                        ToBeDeletedComment.Content,
                        ToBeDeletedComment.TicketId,
                        ToBeDeletedComment.UserId,
                    }
                });

            var compiler = new SqlServerCompiler();
            SqlResult result = compiler.Compile(query);

            return result.ToString();
        }
    }
}