using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
