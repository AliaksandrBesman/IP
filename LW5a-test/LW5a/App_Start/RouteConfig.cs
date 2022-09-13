using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LW5a
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
    name: "Default2",
    url: "{id}/{name}",
    defaults: new { controller = "Test", action = "Index" },
    constraints: new { id = @"\d+" } );
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            //         routes.MapRoute(
            //    name: "Default",
            //    url: "Gordon{hui}",
            //    defaults: new { controller = "Test", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
