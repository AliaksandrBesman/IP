using Microsoft.EntityFrameworkCore;

namespace LW8a.Models
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
