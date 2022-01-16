namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces.Base;
    using System.Collections.Generic;

    public interface IProjectDao : IDaoBase<Ticket>
    {
        IEnumerable<Project> GetByOwnerId(int userId);

        void CreateAccess(IEnumerable<ProjectAccess> projectAccesses);

        IEnumerable<Project> GetByStandardAccess(int projectId);

        IEnumerable<Project> GetByManagerAccess(int projectId);

        void DeleteAccess(int projectId);
    }
}