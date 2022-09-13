using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW5b.Controllers
{
    [RoutePrefix("it")]
    public class MResearchController : Controller
    {
        // GET: MResearch
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("{n:int}/{str}")]
        public ActionResult M01B( int n, string str)
        {
            return Content($"GET:M01B/{n}/{str}");
        }

        [Route("{b:bool}/{letters:alpha}")]
        [AcceptVerbs("get", "post")]
        public ActionResult M02(bool b, string letters)
        {
            return Content($"{Request.HttpMethod}:M02/{b}/{letters}");
        }

        [Route("{f:float}/{str:length(2, 5)}")]
        [AcceptVerbs("get", "delete")]
        public ActionResult M03(float f, string str)
        {
            return Content($"{Request.HttpMethod}:M03/{f}/{str}");
        }

        [Route("{letters:length(3, 4)}/{n:range(100, 200)}")]
        [HttpPut]
        public ActionResult M04(string letters, int n)
        {
            return Content($"PUT:M04/{letters}/{n}");
        }

        [Route(@"{mail:regex([A - Za - z0 - 9._ % +-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4})}")]
        [HttpPost]
        public ActionResult M05(string mail)
        {
            return Content($"POST:M05/{mail}");
        }

    }
}