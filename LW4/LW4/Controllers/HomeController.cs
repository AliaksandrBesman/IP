using LW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW4.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        TelephoneNumberContext db = new TelephoneNumberContext();
        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<TelephoneNumber> books = db.telephoneNumbers;
            TelephoneNumber telephoneNumber = new TelephoneNumber();
            telephoneNumber.Id = 0;
            telephoneNumber.Name = "Alex";
            telephoneNumber.PhoneNumber = "33333";
            db.telephoneNumbers.Add(telephoneNumber);
            db.SaveChanges();
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            // возвращаем представление
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}