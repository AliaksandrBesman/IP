using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class StudentsTasks
    {
        public int DId { get; set; }
        public string DName { get; set; }
        public string DTitle { get; set; }
        public int SId { get; set; }
        public string SName { get; set; }
        public string STitle { get; set; }
        public int TId { get; set; }
        public string TName { get; set; }
        public string TTitle { get; set; }
        public int StId { get; set; }
        public string StName { get; set; }
        public string StTitle { get; set; }
        public string StStatus { get; set; }
        public int? StAssignedById { get; set; }
    }
}
