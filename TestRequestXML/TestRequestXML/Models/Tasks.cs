using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class Tasks
    {
        public Tasks()
        {
            InverseTaskNode = new HashSet<Tasks>();
            Notices = new HashSet<Notices>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? TaskNodeId { get; set; }
        public int? AssignedById { get; set; }
        public int? CreatedById { get; set; }
        public int? StatusId { get; set; }
        public int? TypeId { get; set; }
        public int? ModeId { get; set; }
        public int? PriorityId { get; set; }

        public virtual Users AssignedBy { get; set; }
        public virtual Users CreatedBy { get; set; }
        public virtual TaskModeVisible Mode { get; set; }
        public virtual TaskPriority Priority { get; set; }
        public virtual TaskStatus Status { get; set; }
        public virtual Tasks TaskNode { get; set; }
        public virtual TaskType Type { get; set; }
        public virtual ICollection<Tasks> InverseTaskNode { get; set; }
        public virtual ICollection<Notices> Notices { get; set; }
    }
}
