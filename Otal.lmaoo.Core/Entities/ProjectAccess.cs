namespace Otal.lmaoo.Core.Entities
{
    public class ProjectAccess
    {
        public int ProjectAccessId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public bool ManagerAccess { get; set; }
    }
}