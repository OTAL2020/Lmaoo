namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.Interfaces;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class FeatureDao : DaoBase, IFeatureDao
    {
        private new readonly IConfiguration _configuration;

        public FeatureDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public Feature GetById(int featureId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Feature>("[dbo].[Feature_GetById]", new { FeatureId = featureId },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public IEnumerable<Feature> GetActiveByProjectId(int projectId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Feature>("[dbo].[Feature_GetActiveByProjectId]", new { ProjectId = projectId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Feature> GetInactiveByProjectId(int projectId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Feature>("[dbo].[Feature_GetInactiveByProjectId]", new { ProjectId = projectId },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}