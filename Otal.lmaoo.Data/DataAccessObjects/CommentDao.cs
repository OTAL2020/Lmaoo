using Dapper;
using Microsoft.Extensions.Configuration;
using Otal.lmaoo.Core.Entities;
using Otal.lmaoo.Data.DataAccessObjects.Base;
using Otal.lmaoo.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otal.lmaoo.Data.DataAccessObjects
{
    public class CommentDao : DaoBase, ICommentDao
    {
        public CommentDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public Comment Create(Comment comment)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Comment>("[dbo].[Comment_Create]", new
                {
                    Content = comment.Content,
                    TicketId = comment.TicketId,
                    UserId = comment.UserId
                },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public Comment GetById(int commentId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Comment>("[dbo].[Comment_GetById]", new { CommentId = commentId },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public IEnumerable<Comment> GetByTicketId(int ticketId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Comment>("[dbo].[Comment_GetByTicketId]", new { TicketId = ticketId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Comment Update(Comment comment)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Comment>("[dbo].[Comment_Update]", new
                {
                    Content = comment.Content,
                    CommentId = comment.CommentId
                },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public void Delete(int commentId)
        {
            using (var con = NewSqlConnection)
            {
                con.Query<Feature>("[dbo].[Comment_Delete]", new { CommentId = commentId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}