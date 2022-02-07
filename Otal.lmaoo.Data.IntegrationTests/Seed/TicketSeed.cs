namespace Otal.lmaoo.Data.IntegrationTests.Seed
{
    using Otal.lmaoo.Core.Entities;
    using SqlKata;
    using SqlKata.Compilers;

    public class TicketSeed : ISeed
    {
        public static Ticket BackLogTicket = new Ticket
        {
            TicketId = 1,
            Summary = "BackLogTicket",
            FeatureId = FeatureSeed.BackLogFeature.FeatureId,
            ReporterId = UserSeed.SuperAdminUser.UserId,
            Progress = Core.Enums.TicketProgress.Backlog,
            Active = true
        };

        public static Ticket InDevTicket = new Ticket
        {
            TicketId = 2,
            Summary = "InDevTicket",
            FeatureId = FeatureSeed.InDevFeature.FeatureId,
            ReporterId = UserSeed.SuperAdminUser.UserId,
            AssigneeId = UserSeed.DeveloperUser.UserId,
            Progress = Core.Enums.TicketProgress.InDevelopment,
            Active = true
        };

        public static Ticket InQaTicket = new Ticket
        {
            TicketId = 3,
            Summary = "InQaTicket",
            FeatureId = FeatureSeed.InQaFeature.FeatureId,
            ReporterId = UserSeed.AdminUser.UserId,
            AssigneeId = UserSeed.ManagerUser.UserId,
            Progress = Core.Enums.TicketProgress.InQA,
            Active = true
        };

        public static Ticket InActiveTicket = new Ticket
        {
            TicketId = 3,
            Summary = "InActiveTicket",
            FeatureId = FeatureSeed.InactiveFeature.FeatureId,
            ReporterId = UserSeed.AdminUser.UserId,
            AssigneeId = UserSeed.DisabledUser.UserId,
            Progress = Core.Enums.TicketProgress.Inactive,
            Active = false
        };

        public string DataType() => "Ticket";

        public int OrderNumber() => 4;

        public string GetAllData()
        {
            var query = new Query("dbo.Ticket")
                .AsInsert(new string[]
                {
                    "Summary", "FeatureId", "ReporterId", "AssigneeId", "Progress", "Active"
                },
                new[]
                {
                    new object[]
                    {
                        BackLogTicket.Summary,
                        BackLogTicket.FeatureId,
                        BackLogTicket.ReporterId,
                        BackLogTicket.AssigneeId,
                        BackLogTicket.Progress.ToString(),
                        BackLogTicket.Active ? 1 : 0,
                    },
                    new object[]
                    {
                        InDevTicket.Summary,
                        InDevTicket.FeatureId,
                        InDevTicket.ReporterId,
                        InDevTicket.AssigneeId,
                        InDevTicket.Progress.ToString(),
                        InDevTicket.Active ? 1 : 0,
                    },
                    new object[]
                    {
                        InQaTicket.Summary,
                        InQaTicket.FeatureId,
                        InQaTicket.ReporterId,
                        InQaTicket.AssigneeId,
                        InQaTicket.Progress.ToString(),
                        InQaTicket.Active ? 1 : 0,
                    },
                    new object[]
                    {
                        InActiveTicket.Summary,
                        InActiveTicket.FeatureId,
                        InActiveTicket.ReporterId,
                        InActiveTicket.AssigneeId,
                        InActiveTicket.Progress.ToString(),
                        InActiveTicket.Active ? 1 : 0,
                    },
                });

            var compiler = new SqlServerCompiler();
            SqlResult result = compiler.Compile(query);

            return result.ToString();
        }
    }
}