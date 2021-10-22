namespace Otal.lmaoo.Core.Entities.User
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
    }
}