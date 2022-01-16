using Otal.lmaoo.Core.Enums;

namespace Otal.lmaoo.Core.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
        public int Owner { get; set; }
        public int Active { get; set; }
    }
}