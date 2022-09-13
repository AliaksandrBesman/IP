using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class ConfirmedStageByAssigned
    {
        public int MtId { get; set; }
        public string MtName { get; set; }
        public int? TAssignedById { get; set; }
        public int? CountTasksInStatusByAssigned { get; set; }
        public int? CountSubtasks { get; set; }
        public string ConfirmedStage { get; set; }
    }
}
