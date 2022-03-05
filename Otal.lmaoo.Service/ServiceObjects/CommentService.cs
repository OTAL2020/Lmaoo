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

        public Comment Create(Comment comment)
        {
             return _commentDao.Create(comment);
        }

        public Comment GetById(int commentId)
        {
            return _commentDao.GetById(commentId);
        }

        public IEnumerable<Comment> GetByTicketId(int TicketId)
        {
            return _commentDao.GetByTicketId(TicketId);
        }

        public Comment Update(Comment comment)
        {
            return _commentDao.Update(comment);
        }
    }
}
