using LW7a.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LW7a.Controllers
{
    public class TSController : ApiController
    {
        private TelephoneNumberContext db = new TelephoneNumberContext();
        [HttpGet]
        public List<TelephoneNumber> TelephoneNumbers()
        {
            return db.telephoneNumbers.ToList();
        }

        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            TelephoneNumber telephoneNumber = db.telephoneNumbers.Find(id);
            if (telephoneNumber == null)
            {
                return NotFound();
            }
            return Ok(telephoneNumber);
        }


        [HttpPost]
        public HttpResponseMessage Add(TelephoneNumber telephoneNumber)
        {
            db.telephoneNumbers.Add(telephoneNumber);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, telephoneNumber);
        }

        [HttpPut]
        public HttpResponseMessage Change(TelephoneNumber telephoneNumber)
        {
            db.Entry(telephoneNumber).State = EntityState.Modified;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, telephoneNumber);
        }

        [HttpDelete]
        public HttpResponseMessage Remove([FromBody]string jj)
        {
            int id = int.Parse(jj);
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Not a valid student id");
            var telephoneNumber = db.telephoneNumbers
                        .Where(s => s.Id == id)
                        .FirstOrDefault();

            if (telephoneNumber == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            db.Entry(telephoneNumber).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
