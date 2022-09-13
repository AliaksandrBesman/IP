using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW3.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            string uri = Request.Params.Get("aspxerrorpath");
            string method = Request.HttpMethod;
            Response.StatusCode = 404;
            ViewBag.uri = uri;
            ViewBag.method = method;
            return View();
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}

    //< httpErrors errorMode = "Custom" existingResponse = "Replace" >
   
    //     < clear />
   
    //     < error statusCode = "404" path = "/Error/NotFound" responseMode = "ExecuteURL" />
        
    //          < error statusCode = "403" path = "/Error/Forbidden" responseMode = "ExecuteURL" />
             
    //             </ httpErrors >