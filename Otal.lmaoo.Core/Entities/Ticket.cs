namespace Otal.lmaoo.Core.Entities
{
    using System;

    public class Ticket
    {
        public int TicketId { get; set; }
        public string Summary { get; set; }
        public int FeatureId { get; set; }
        public int ReporterId { get; set; }
        public string ReporterName { get; set; }
        public string ReporterUsername { get; set; }
        public int AssigneeId { get; set; }
        public string AssigneeName { get; set; }
        public string AssigneeUsername { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Progress { get; set; }
        public DateTime Deadline { get; set; }
        public bool Active { get; set; }
    }
}