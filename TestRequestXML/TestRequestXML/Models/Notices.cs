using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class Notices
    {
        public int Id { get; set; }
        public int? AssignedById { get; set; }
        public int? TaskId { get; set; }

        public virtual Users AssignedBy { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
