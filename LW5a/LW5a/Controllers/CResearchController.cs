using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW5a.Controllers
{
    public class CResearchController : Controller
    {
        // GET: CResearch
        public ActionResult Index()
        {
            return View();
        }

        public string C01()
        {
            string body;
            string form;
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
                form = Request.Form.ToString();
            }
            return "C01: \r" + 
                    (Request.HttpMethod == "POST" ? $"<h3>body:</h3> {body}; <h3> form:</h3> {form} " : "") +
                    $"<h3>headers:</h3> {Request.Headers.ToString()}; " +
                    $"<h3>method:</h3> {Request.HttpMethod}; " +
                    $"<h3>uri:</h3> {Request.Url.AbsoluteUri}; " +
                    $"<h3>params:</h3> {Request.QueryString["param"]}; ";
        }

        public string C02()
        {
            string body;

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                body = reader.ReadToEnd();
            }
            return "C02: \r" + 
                $"<h3>body:</h3> {body};" + 
                $"<h3>header:</h3> {Request.Headers.ToString()};" + 
                $"<h3>status:</h3> {HttpContext.Response.StatusCode.ToString()}";
        }
    
    }
}