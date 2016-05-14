using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace notepad
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Imageloader",
                url: "Imageload",
                defaults: new { controller = "Home", action = "Imageload", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Save",
                url: "Save",
                defaults: new { controller = "Home", action = "Save", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Load",
                url: "Load",
                defaults: new { controller = "Home", action = "Load"}
            );
            routes.MapRoute(
                name: "Create",
                url: "Create",
                defaults: new { controller = "Home", action = "Create"}
            );
                routes.MapRoute(
                name: "select",
                url: "{id}",
                defaults: new { controller = "Home", action = "Select",id= UrlParameter.Optional}
            );
                
                    
                    
        }
    }
}
