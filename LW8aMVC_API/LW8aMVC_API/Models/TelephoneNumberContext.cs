using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LW8aMVC_API.Models
{
    public class TelephoneNumberContext : DbContext
    {
        public DbSet<TelephoneNumber> telephoneNumbers { get; set; }
        public TelephoneNumberContext(DbContextOptions<TelephoneNumberContext> options)
    : base(options)
        {
            Database.EnsureCreated(); 
        }
    }
}
