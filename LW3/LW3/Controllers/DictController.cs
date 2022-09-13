using LW3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LW3.Controllers
{
    public class DictController : Controller
    {
        private TelephoneNumberContext telephoneNumberContext = new TelephoneNumberContext();
        // GET: Dict
        public ActionResult Index()
        {
            return View(telephoneNumberContext.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave( TelephoneNumber telephoneNumber)
        {

            telephoneNumberContext.Create(telephoneNumber);
                return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelephoneNumber telephoneNumber = telephoneNumberContext.Find(id.Value);
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
                telephoneNumberContext.Update(telephoneNumber);
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
            TelephoneNumber telephoneNumber = telephoneNumberContext.Find(id.Value);
            if (telephoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(telephoneNumber);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(int id)
        {
            telephoneNumberContext.Delete(id);
            return RedirectToAction("Index");
        }


    }
}