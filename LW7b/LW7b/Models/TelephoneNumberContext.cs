using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LW7b.Models
{
    public class TelephoneNumberContext : DbContext
    {
        public DbSet<TelephoneNumber> telephoneNumbers { get; set; }
        public TelephoneNumberContext(DbContextOptions<TelephoneNumberContext> options)
    : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}