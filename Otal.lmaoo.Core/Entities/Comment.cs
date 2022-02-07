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
        public string UserForename { get; set; }
        public string UserSurname { get; set; }
        public string UserPicture { get; set; }
    }
}