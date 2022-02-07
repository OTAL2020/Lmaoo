﻿namespace Otal.lmaoo.Data.IntegrationTests.Seed
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
                });

            var compiler = new SqlServerCompiler();
            SqlResult result = compiler.Compile(query);

            return result.ToString();
        }
    }
}