namespace Otal.lmaoo.Core.Enums
{
    public enum TicketProgress
    {
        Backlog = 0,

        Open = 1,
        InDevelopment = 2,

        Building = 3,
        BuildFailed = 4,
        PullRequestInReview = 5,
        PullRequestDenied = 6,

        DeploymentQA = 7,
        ReadyForQA = 8,
        InQA = 9,

        ReadyToDeploy = 10,
        MainBranchPullRequestReview = 11,
        DeploymentToMain = 12,
        Completed = 13
    }
}