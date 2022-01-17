namespace Otal.lmaoo.Data.DataAccessObjects
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Data.DataAccessObjects.Base;
    using Otal.lmaoo.Data.Interfaces;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class ProjectDao : DaoBase, IProjectDao
    {
        private new static IConfiguration _configuration;

        public ProjectDao(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public Project Create(Project project)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Project>("[dbo].[Project_Create]", new
                {
                    Name = project.Name,
                    Status = project.Status,
                    Owner = project.Owner
                },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public void CreateAccess(IEnumerable<ProjectAccess> projectAccesses)
        {
            foreach (var access in projectAccesses)
            {
                using (var con = NewSqlConnection)
                {
                    con.Query<Project>("[dbo].[Project_CreateAccess]", new
                    {
                        ProjectId = access.ProjectId,
                        UserId = access.UserId,
                        ManagerAccess = access.ManagerAccess
                    },
                        commandType: CommandType.StoredProcedure);
                }
            }
        }

        public Project GetById(int projectId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Project>("[dbo].[Project_GetById]", new { ProjectId = projectId },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public IEnumerable<Project> GetByStandardAccess(int projectId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Project>("[dbo].[Project_GetByStandardAccess]", new { ProjectId = projectId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Project> GetByManagerAccess(int projectId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Project>("[dbo].[Project_GetByManagerAccess]", new { ProjectId = projectId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Project> GetByOwnerId(int userId)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Project>("[dbo].[Project_GetByOwnerId]", new { UserId = userId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Project Update(Project project)
        {
            using (var con = NewSqlConnection)
            {
                return con.Query<Project>("[dbo].[Project_Update]", new
                {
                    Name = project.Name,
                    Status = project.Status,
                    ProjectId = project.ProjectId
                },
                    commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public void Delete(int projectId)
        {
            using (var con = NewSqlConnection)
            {
                con.Query<Project>("[dbo].[Project_Delete]", new { ProjectId = projectId }, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteAccess(int projectId)
        {
            using (var con = NewSqlConnection)
            {
                con.Query<ProjectAccess>("[dbo].[Project_DeleteAccess]", new { ProjectId = projectId }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}