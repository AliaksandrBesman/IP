using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestRequestXML.Models
{
    public partial class Users
    {
        public Users()
        {
            InverseManager = new HashSet<Users>();
            Notices = new HashSet<Notices>();
            TasksAssignedBy = new HashSet<Tasks>();
            TasksCreatedBy = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public int? Age { get; set; }
        public int? RoleId { get; set; }
        public int? ManagerId { get; set; }

        public virtual Users Manager { get; set; }
        public virtual UserRoles Role { get; set; }
        public virtual UserDetails UserDetails { get; set; }
        public virtual ICollection<Users> InverseManager { get; set; }
        public virtual ICollection<Notices> Notices { get; set; }
        public virtual ICollection<Tasks> TasksAssignedBy { get; set; }
        public virtual ICollection<Tasks> TasksCreatedBy { get; set; }
    }
}
