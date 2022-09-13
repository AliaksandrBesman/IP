using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LW7a.Models
{
    public class TelephoneNumberContext : DbContext
    {
        public DbSet<TelephoneNumber> telephoneNumbers { get; set; }
    }
}