using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LW4.Models;

namespace LW4.Controllers
{
    public class TelephoneNumbersController : Controller
    {
        private TelephoneNumberContext db = new TelephoneNumberContext();

        // GET: TelephoneNumbers
        public ActionResult Index()
        {
            return View(db.telephoneNumbers.ToList());
        }

        // GET: TelephoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneNumber telephoneNumber = db.telephoneNumbers.Find(id);
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
                db.telephoneNumbers.Add(telephoneNumber);
                db.SaveChanges();
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
            TelephoneNumber telephoneNumber = db.telephoneNumbers.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber")] TelephoneNumber telephoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telephoneNumber).State = EntityState.Modified;
                db.SaveChanges();
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
            TelephoneNumber telephoneNumber = db.telephoneNumbers.Find(id);
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
            TelephoneNumber telephoneNumber = db.telephoneNumbers.Find(id);
            db.telephoneNumbers.Remove(telephoneNumber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
