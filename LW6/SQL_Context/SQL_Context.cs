using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDictionary;

namespace SQL_Context
{
    class SQL_Context:DbContext
    {
        public DbSet<TelephoneNumber> telephoneNumbers { get; set; }
    }
}
