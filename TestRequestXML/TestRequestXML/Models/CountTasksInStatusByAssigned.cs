using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class CountTasksInStatusByAssigned
    {
        public int MtId { get; set; }
        public string MtName { get; set; }
        public int? MtTaskNodeId { get; set; }
        public int? MtAssignedById { get; set; }
        public int? MtStatusId { get; set; }
        public int SbId { get; set; }
        public string SbName { get; set; }
        public int? SbTaskNodeId { get; set; }
        public int? SbAssignedById { get; set; }
        public int? SbStatusId { get; set; }
        public int TId { get; set; }
        public string TName { get; set; }
        public int? TTaskNodeId { get; set; }
        public int? TAssignedById { get; set; }
        public int? TStatusId { get; set; }
        public int? CountTasksInStatusByAssigned1 { get; set; }
    }
}
