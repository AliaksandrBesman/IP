using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_Service.Models;

namespace WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TS" in both code and config file together.
    public class TS : ITS
    {
        private TelephoneNumberContext db = new TelephoneNumberContext();

        public TelephoneNumber AddDict(TelephoneNumber telephoneNumber)
        {
            db.telephoneNumbers.Add(telephoneNumber);
            db.SaveChanges();
            return telephoneNumber;
        }

        public TelephoneNumber DelDict(string jj)
        {
            int id = int.Parse(jj);
            if (id <= 0)
                throw new Exception("Not Found");
            var telephoneNumber = db.telephoneNumbers
                        .Where(s => s.Id == id)
                        .FirstOrDefault();

            if (telephoneNumber == null)
                throw new Exception("Not Found");
            db.Entry(telephoneNumber).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return telephoneNumber;
        }

        public List<TelephoneNumber> GetDict()
        {
            
            return db.telephoneNumbers.ToList();
        }

        public TelephoneNumber UpdDict(TelephoneNumber telephoneNumber)
        {
            db.Entry(telephoneNumber).State = EntityState.Modified;
            db.SaveChanges();
            return telephoneNumber;
        }
    }
}
