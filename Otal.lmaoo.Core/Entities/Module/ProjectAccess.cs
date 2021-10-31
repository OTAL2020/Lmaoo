namespace Otal.lmaoo.Core.Entities.ProjectAccess
{
    public class ProjectAccess
    {
        public int ProjectAccessId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public byte AllowAccess { get; set; }
        public byte ManagerAccess { get; set; }
    }
}