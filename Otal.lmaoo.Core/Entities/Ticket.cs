namespace Otal.lmaoo.Core.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Summary { get; set; }
        public int FeatureId { get; set; }
        public int Reporter { get; set; }
        public int Assignee { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Progess { get; set; }
        public DateTime Deadline { get; set; }
    }
}