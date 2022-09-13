using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JSON_Context;
using TelephoneDictionary;

namespace LW3.Controllers
{
    public class DictController : Controller
    {
        ITelephoneDictionary db ;

        public DictController(ITelephoneDictionary td)
        {
            this.db = td;
        }
        // GET: Dict
        public ActionResult Index()
        {
            return View(db.List());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave( TelephoneNumber telephoneNumber)
        {

            db.Add(telephoneNumber);
                return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult Update(int? id)
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

        [HttpPost]
        public ActionResult UpdateSave(TelephoneNumber telephoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Edit(telephoneNumber);
                return RedirectToAction("Index");
            }
            return View(telephoneNumber);
        }

        [HttpGet]
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

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(int id)
        {
            db.Remove(id);
            return RedirectToAction("Index");
        }


    }
}