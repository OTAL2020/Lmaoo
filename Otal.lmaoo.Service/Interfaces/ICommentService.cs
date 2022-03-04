namespace Otal.lmaoo.Service.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using System.Collections.Generic;

    public interface ICommentService
    {
        Comment CreateComment(Comment comment);
        Comment GetCommentById(int commentId);
        IEnumerable <Comment> GetCommentByTicketId(int ticketId);
    }
}
