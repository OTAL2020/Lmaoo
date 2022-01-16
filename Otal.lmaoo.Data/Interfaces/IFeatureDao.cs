﻿namespace Otal.lmaoo.Data.Interfaces
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces.Base;
    using System.Collections.Generic;

    public interface IFeatureDao : IDaoBase<Feature>
    {
        IEnumerable<Feature> GetActiveByProjectId(int projectId);

        IEnumerable<Feature> GetInactiveByProjectId(int projectId);
    }
}