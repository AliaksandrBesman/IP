using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelephoneDictionary;

namespace LW4.Controllers
{  
    public class TelephoneNumbersController : Controller
    {
        ITelephoneDictionary db;

        public TelephoneNumbersController(ITelephoneDictionary td)
        {
            this.db = td;
        }

        // GET: TelephoneNumbers
        public ActionResult Index()
        {
            return View(db.List());
        }

        // GET: TelephoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneNumber telephoneNumber =  db.Find(id.Value);
            if (telephoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TelephoneNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNumber")] TelephoneNumber telephoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Add(telephoneNumber);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneNumber telephoneNumber = db.Find(id.Value);
            if (telephoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(telephoneNumber);
        }

        // POST: TelephoneNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber")]  TelephoneNumber telephoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Edit(telephoneNumber);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(telephoneNumber);
        }

        // GET: TelephoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneNumber telephoneNumber = db.Find(id.Value);
            if (telephoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(telephoneNumber);
        }

        // POST: TelephoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Remove(id);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
