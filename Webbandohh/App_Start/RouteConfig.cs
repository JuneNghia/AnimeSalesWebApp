using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webbandohh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Add Cart",
                url: "add-cart",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "Webbandohh.Controllers" }
            );
            routes.MapRoute(
                name: "Delete Cart",
                url: "delete-cart",
                defaults: new { controller = "Cart", action = "Delete", id = UrlParameter.Optional },
                namespaces: new[] { "Webbandohh.Controllers" }
            );
            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Webbandohh.Controllers" }
            );
        }
    }
}
