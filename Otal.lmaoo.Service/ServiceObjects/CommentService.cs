namespace Otal.lmaoo.Service.ServiceObjects
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using Otal.lmaoo.Service.Interfaces;
    using System.Collections.Generic;

    public class CommentService : ICommentService
    {
        protected readonly ICommentDao _commentDao;

        public CommentService(ICommentDao commentDao)
        {
            _commentDao = commentDao;
        }

        public Comment CreateComment(Comment comment)
        {
             return _commentDao.Create(comment);
        }

        public Comment GetCommentById(int commentId)
        {
            return _commentDao.GetById(commentId);
        }

        public IEnumerable<Comment> GetCommentByTicketId(int TicketId)
        {
            return _commentDao.GetByTicketId(TicketId);
        }

        public Comment UpdateComment(Comment comment)
        {
            return _commentDao.Update(comment);
        }
    }
}
