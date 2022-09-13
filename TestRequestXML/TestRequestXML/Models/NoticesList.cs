using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class NoticesList
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public string ReporterName { get; set; }
        public string ReporterSurname { get; set; }
        public string ReporterSecondName { get; set; }
        public int? NoticeOwner { get; set; }
    }
}
