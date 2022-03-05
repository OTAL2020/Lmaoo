namespace Otal.lmaoo.Service.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using System.Collections.Generic;

    public interface ICommentService
    {
        Comment Create(Comment comment);
        Comment GetById(int commentId);
        IEnumerable<Comment> GetByTicketId(int ticketId);
    }
}
