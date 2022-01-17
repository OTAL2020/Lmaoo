namespace Otal.lmaoo.Core.Entities
{
    using System;

    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
    }
}