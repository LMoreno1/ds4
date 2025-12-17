using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace ProyectoFinal
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.Ignore("api/{*pathInfo}");

            routes.MapPageRoute(
                "Default",
                "",
                "~/Default.aspx"
            );

            routes.MapPageRoute(
                "Productos",
                "productos/{categoria}",
                "~/Productos.aspx"
            );

            routes.MapPageRoute(
                "Paginas",
                "{pagina}",
                "~/{pagina}.aspx"
            );
        }
    }
}
