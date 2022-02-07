using Otal.lmaoo.Core.Enums;

namespace Otal.lmaoo.Core.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
        public int OwnerId { get; set; }
        public bool Active { get; set; }
    }
}