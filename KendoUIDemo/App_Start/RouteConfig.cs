using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KendoUIDemo.Helpers;

namespace KendoUIDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.Add("Default", new Route(
            //    "{controller}/{action}",
            //    new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } },
            //    new HyphenatedRouteHandler()
            //));

        }
    }
}
