namespace Otal.lmaoo.Data.IntegrationTests.Seed
{
    using Otal.lmaoo.Core.Entities;
    using Otal.lmaoo.Core.Enums;
    using SqlKata;
    using SqlKata.Compilers;

    public class ProjectSeed : ISeed
    {
        public static Project BacklogProject = new Project
        {
            ProjectId = 1,
            Name = "BacklogProject",
            Status = ProjectStatus.Backlog,
            OwnerId = UserSeed.ManagerUser.UserId,
            Active = true
        };

        public static Project InDevProject = new Project
        {
            ProjectId = 2,
            Name = "InDevProject",
            Status = ProjectStatus.InDev,
            OwnerId = UserSeed.AdminUser.UserId,
            Active = true
        };

        public static Project InQaProject = new Project
        {
            ProjectId = 3,
            Name = "StandardProject",
            Status = ProjectStatus.InQa,
            OwnerId = UserSeed.SuperAdminUser.UserId,
            Active = true
        };

        public static Project DoneProject = new Project
        {
            ProjectId = 4,
            Name = "StandardProject",
            Status = ProjectStatus.Done,
            OwnerId = UserSeed.DeveloperUser.UserId,
            Active = true
        };

        public static Project InactiveProject = new Project
        {
            ProjectId = 5,
            Name = "InactiveProject",
            Status = ProjectStatus.InQa,
            OwnerId = UserSeed.DeveloperUser.UserId,
            Active = false
        };

        public int OrderNumber() => 2;

        public string DataType() => "Project";

        public string GetAllData()
        {
            var query = new Query("dbo.Project")
                .AsInsert(new string[]
                {
                    "Name", "Status", "OwnerId", "Active"
                },
                new[]
                {
                    new object[]
                    {
                        BacklogProject.Name,
                        BacklogProject.Status,
                        BacklogProject.OwnerId,
                        BacklogProject.Active ? 1 : 0,
                    },
                    new object[]
                    {
                        InDevProject.Name,
                        InDevProject.Status,
                        InDevProject.OwnerId,
                        InDevProject.Active ? 1 : 0,
                    },
                    new object[]
                    {
                        InQaProject.Name,
                        InQaProject.Status,
                        InQaProject.OwnerId,
                        InQaProject.Active ? 1 : 0,
                    },
                    new object[]
                    {
                        DoneProject.Name,
                        DoneProject.Status,
                        DoneProject.OwnerId,
                        DoneProject.Active ? 1 : 0,
                    },
                    new object[]
                    {
                        InactiveProject.Name,
                        InactiveProject.Status,
                        InactiveProject.OwnerId,
                        InactiveProject.Active ? 1 : 0,
                    }
                });

            var compiler = new SqlServerCompiler();
            SqlResult result = compiler.Compile(query);

            return result.ToString();
        }
    }
}