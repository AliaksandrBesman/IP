using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDictionary;

namespace JSON_Context
{
    public class JSON_Repository : ITelephoneDictionary
    {
        private JSONContext db;

        public JSON_Repository()
        {
            this.db = new JSONContext();
        }

        public TelephoneNumber Add(TelephoneNumber item)
        {
            return db.Create(item);
        }

        public TelephoneNumber Edit(TelephoneNumber item)
        {
            return db.Update(item);
        }

        public TelephoneNumber Find(int id)
        {
            return db.Find(id);
        }

        public IEnumerable<TelephoneNumber> List()
        {
            return db.GetAll();
        }

        public TelephoneNumber Remove(int item)
        {
            return db.Delete(item);
        }

        public void Save()
        {
            db.Save();
        }
    }
}
