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
            Owner = UserSeed.ManagerUser.UserId,
            Active = 1
        };

        public static Project InDevProject = new Project
        {
            ProjectId = 2,
            Name = "InDevProject",
            Status = ProjectStatus.InDev,
            Owner = UserSeed.AdminUser.UserId,
            Active = 1
        };

        public static Project InQaProject = new Project
        {
            ProjectId = 3,
            Name = "StandardProject",
            Status = ProjectStatus.InQa,
            Owner = UserSeed.SuperAdminUser.UserId,
            Active = 1
        };

        public static Project DoneProject = new Project
        {
            ProjectId = 4,
            Name = "StandardProject",
            Status = ProjectStatus.Done,
            Owner = UserSeed.DeveloperUser.UserId,
            Active = 1
        };

        public static Project InactiveProject = new Project
        {
            ProjectId = 5,
            Name = "InactiveProject",
            Status = ProjectStatus.InQa,
            Owner = UserSeed.DeveloperUser.UserId,
            Active = 0
        };

        public int OrderNumber() => 2;

        public string DataType() => "Project";

        public string GetAllData()
        {
            var query = new Query("dbo.User")
                .AsInsert(new string[]
                {
                    "Name", "Status", "Owner", "Active"
                },
                new[]
                {
                    new object[]
                    {
                        BacklogProject.Name,
                        BacklogProject.Status,
                        BacklogProject.Owner,
                        BacklogProject.Active,
                    },
                    new object[]
                    {
                        InDevProject.Name,
                        InDevProject.Status,
                        InDevProject.Owner,
                        InDevProject.Active,
                    },
                    new object[]
                    {
                        InQaProject.Name,
                        InQaProject.Status,
                        InQaProject.Owner,
                        InQaProject.Active,
                    },
                    new object[]
                    {
                        DoneProject.Name,
                        DoneProject.Status,
                        DoneProject.Owner,
                        DoneProject.Active,
                    },
                    new object[]
                    {
                        InactiveProject.Name,
                        InactiveProject.Status,
                        InactiveProject.Owner,
                        InactiveProject.Active,
                    },
                });

            var compiler = new SqlServerCompiler();
            SqlResult result = compiler.Compile(query);

            return result.ToString();
        }
    }
}