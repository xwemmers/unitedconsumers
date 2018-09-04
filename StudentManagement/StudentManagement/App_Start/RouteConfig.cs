using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.jpg/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default2",
                url: "Zoeken",
                defaults: new { controller = "Home", action = "SearchStudent" }
            );

            //routes.MapRoute(
            //    name: "Default3",
            //    url: "ZoekenOpJaar/{jaar}",
            //    defaults: new { controller = "Home", action = "SearchStudent" },
            //    constraints:  new { jaar = "[0-9]{4}" }
            //);

            //routes.MapRoute(
            //    name: "Default4",
            //    url: "{action}.asp",
            //    defaults: new { controller = "Home", action = "Station" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
