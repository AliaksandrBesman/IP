﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class TasksStat
    {
        public int? TaskNodeId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? StStatus { get; set; }
    }
}
