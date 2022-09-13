using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW5a.Controllers
{
    public class MResearchController : Controller
    {
        // GET: MResearch
        public ActionResult Index()
        {
            return View();            
        }

        public string M01(int ?id)
        {
            return "Hello M01: " + id.ToString();
        }

        public string M02()
        {
            return "Hello M02: ";
        }

        public string M03()
        {
            return "Hello M03: ";
        }

        //ERROR
        public string MXX()
        {
           
            return "MXX";
        }
    }
}