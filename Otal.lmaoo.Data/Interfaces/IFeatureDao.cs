using Otal.lmaoo.Core.Entities;
using System.Collections.Generic;

namespace Otal.lmaoo.Data.Interfaces
{
    public interface IFeatureDao
    {
        Feature GetById(int id);

        IEnumerable<Feature> GetActiveByProjectId(int projectId);

        IEnumerable<Feature> GetInactiveByProjectId(int projectId);
    }
}