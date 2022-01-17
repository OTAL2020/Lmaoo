namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces.Base;
    using System.Collections.Generic;

    public interface ICommentDao : IDaoBase<Comment>
    {
        IEnumerable<Comment> GetByTicketId(int ticketId);
    }
}