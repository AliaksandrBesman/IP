using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LW1a
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("get_handler/{*path}");
            routes.IgnoreRoute("post_handler/{*path}");
            routes.IgnoreRoute("put_handler/{*path}");
            routes.IgnoreRoute("sum_handler/{*path}");
            routes.IgnoreRoute("mul_handler/{*path}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
