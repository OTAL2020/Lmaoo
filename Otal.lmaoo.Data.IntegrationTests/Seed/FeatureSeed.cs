namespace Otal.lmaoo.Data.IntegrationTests.Seed
{
    using Otal.lmaoo.Core.Entities;
    using SqlKata;
    using SqlKata.Compilers;

    public class FeatureSeed : ISeed
    {
        public static Feature BackLogFeature = new Feature
        {
            FeatureId = 1,
            Name = "BackLogFeature",
            ProjectId = ProjectSeed.BacklogProject.ProjectId,
            Active = 1
        };

        public static Feature InDevFeature = new Feature
        {
            FeatureId = 2,
            Name = "InDevFeature",
            ProjectId = ProjectSeed.InDevProject.ProjectId,
            Active = 1
        };

        public static Feature InQaFeature = new Feature
        {
            FeatureId = 3,
            Name = "InQaFeature",
            ProjectId = ProjectSeed.InQaProject.ProjectId,
            Active = 1
        };

        public static Feature InactiveFeature = new Feature
        {
            FeatureId = 4,
            Name = "BackLogFeature",
            ProjectId = ProjectSeed.InactiveProject.ProjectId,
            Active = 0
        };

        public int OrderNumber() => 3;

        public string DataType() => "Feature";

        public string GetAllData()
        {
            var query = new Query("dbo.Feature")
                .AsInsert(new string[]
                {
                    "Name", "ProjectId", "Active"
                },
                new[]
                {
                    new object[]
                    {
                        BackLogFeature.Name,
                        BackLogFeature.ProjectId,
                        BackLogFeature.Active,
                    },
                    new object[]
                    {
                        InDevFeature.Name,
                        InDevFeature.ProjectId,
                        InDevFeature.Active,
                    },
                    new object[]
                    {
                        InQaFeature.Name,
                        InQaFeature.ProjectId,
                        InQaFeature.Active,
                    },
                    new object[]
                    {
                        InactiveFeature.Name,
                        InactiveFeature.ProjectId,
                        InactiveFeature.Active,
                    }
                });

            var compiler = new SqlServerCompiler();
            SqlResult result = compiler.Compile(query);

            return result.ToString();
        }
    }
}