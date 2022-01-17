namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces.Base;
    using System.Collections.Generic;

    public interface ITicketDao : IDaoBase<Ticket>
    {
        IEnumerable<Ticket> GetByFeatureId(int featureId);
    }
}