using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class ConfirmedStageStudents
    {
        public string NodeName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CountConfirmedStageStudent { get; set; }
        public int? CountStageStudent { get; set; }
    }
}
