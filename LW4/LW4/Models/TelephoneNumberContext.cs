using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LW4.Models
{
    public class TelephoneNumberContext:DbContext
    {
        public DbSet<TelephoneNumber> telephoneNumbers { get; set; }
    }
}