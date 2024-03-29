﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW5b.Controllers
{   
    public class AResearchController : Controller
    {
        // GET: AResearch
        [AAFilter]
        public ActionResult Index()
        {
            return View();
        }

        [AAFilter]
        public ActionResult AA()
        {
            return Content("AA result\n");
        }
        [AAFilter]
        [ARFilter]
        public ActionResult AR()
        {
            //HttpContext.Response.StatusCode = 308;
            return Content($"AR result\n");
        }

        [AEFilter]
        public ActionResult AE()
        {
            throw new Exception("Exception in AE Action");
            return Content($"AE worked right\n");
        }

        public class AAFilter : FilterAttribute, IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AA:Вызов перед вызовом метода действия\n");
            }

            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AA:Вызов после работы метода действия\n");
            }

        }

        public class ARFilter : FilterAttribute, IResultFilter
        {
            public void OnResultExecuted(ResultExecutedContext filterContext)
            {

                filterContext.HttpContext.Response.Write("Время текущего запроса HTTP: " + filterContext.HttpContext.Timestamp);
            }

            public void OnResultExecuting(ResultExecutingContext filterContext)
            {

                filterContext.HttpContext.Response.Write("Текущий пользователь: " + filterContext.HttpContext.User.Identity.Name);
            }
        }

        public class AEFilter : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                filterContext.HttpContext.Response.Write("AE:Вызвано исключение\n");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}