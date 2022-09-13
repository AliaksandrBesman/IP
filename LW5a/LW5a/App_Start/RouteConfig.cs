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
                name: "Default1",
                url: "V2/{controller}/{action}",
                defaults: new { controller = "MResearch", action = "M02" },
                constraints: new { action = "M01|M02" , controler = "MResearch|^$" }
            );

            routes.MapRoute(
                name: "Default2",
                url: "V3",
                defaults: new { controller = "MResearch", action = "M03" }

            );

            routes.MapRoute(
                name: "Default3",
                url: "V3/MResearch/X/{action}",
                defaults: new { controller = "MResearch", action = "M03", X = UrlParameter.Optional }

            );

            routes.MapRoute(
                name: "Defaul4",
                url: "CResearch/{action}/{id}",
                defaults: new { controller = "CResearch", action = "C01", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Defaul5",
                url: "MResearch/M01/1",
                defaults: new { controller = "MResearch", action = "M01", id="1" }
            );

            routes.MapRoute(
                name: "Defaul6",
                url: "MResearch/{action}",
                defaults: new { controller = "MResearch", action = "M01" },
                constraints: new { action = "M01|M02" }
            );

            routes.MapRoute(
                name: "Default7",
                url: "",
                defaults: new { controller = "MResearch", action = "M01" }
            );

            routes.MapRoute(
                name: "Default8",
                url: "{*catchall}",
                defaults: new { controller = "MResearch", action = "MXX" }
            );

        }
    }
}
