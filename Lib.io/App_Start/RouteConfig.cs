using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lib.io {
    public class RouteConfig {
		// Order of Routes matter.
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Enable MVC Attribute Routes
            routes.MapMvcAttributeRoutes();

            // Custom Route using Convention-based Routing
            /*
            routes.MapRoute(
                name: "BooksByReleaseDate",
                url: "books/released/{year}/{month}",
                defaults: new { controller = "Books", action = "ByReleaseDate" },
                constraints: new { year = "\\d{4}", month = "\\d{2}" }
            );
            */
			
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
