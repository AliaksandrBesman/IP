using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class UserDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Faculty { get; set; }
        public string Speciality { get; set; }
        public int? Course { get; set; }
        public int? Group { get; set; }
        public int? Subgroup { get; set; }

        public virtual Users User { get; set; }
    }
}
