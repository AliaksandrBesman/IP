using LW7b.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LW7b
{
    /// <summary>
    /// Summary description for TSService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TSService : System.Web.Services.WebService
    {
        private TelephoneNumberContext db = new TelephoneNumberContext();

        [WebMethod(EnableSession =true)]
        public List<TelephoneNumber> GetDict()
        {
            return db.telephoneNumbers.ToList();
        }

        [WebMethod(EnableSession = true)]
        public TelephoneNumber AddDict(TelephoneNumber telephoneNumber)
        {
            db.telephoneNumbers.Add(telephoneNumber);
            db.SaveChanges();
            return telephoneNumber;
        }

        [WebMethod(EnableSession = true)]
        public TelephoneNumber UpdDict(TelephoneNumber telephoneNumber)
        {
            db.Entry(telephoneNumber).State = EntityState.Modified;
            db.SaveChanges();
            return telephoneNumber;
        }

        [WebMethod(EnableSession = true)]
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

    }
}
