using System.Data.Entity;

namespace WCF_Service.Models
{
    public class TelephoneNumberContext : DbContext
    {
        public DbSet<TelephoneNumber> telephoneNumbers { get; set; }
    }
}
