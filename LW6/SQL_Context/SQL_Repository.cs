using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDictionary;

namespace SQL_Context
{
    public class SQL_Repository : ITelephoneDictionary
    {
        private SQL_Context db = new SQL_Context();

        public TelephoneNumber Add(TelephoneNumber item)
        {
            return db.telephoneNumbers.Add(item);
        }

        public TelephoneNumber Edit(TelephoneNumber item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public TelephoneNumber Find(int id)
        {
            return db.telephoneNumbers.Find(id);
        }

        public IEnumerable<TelephoneNumber> List()
        {
            return db.telephoneNumbers.ToList();
        }

        public TelephoneNumber Remove(int item)
        {
            TelephoneNumber telephoneNumber = db.telephoneNumbers.Find(item);
            db.telephoneNumbers.Remove(telephoneNumber);
            return telephoneNumber;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
