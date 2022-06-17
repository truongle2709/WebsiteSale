using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SanPham", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"ShopColor.Controller"} 
            );

            routes.MapRoute(
               name: "listproduct",
               url: "list-product",
               defaults: new { controller = "SanPham", action = "DanhSachSanPham", id = UrlParameter.Optional },
               namespaces: new[] { "ShopColor.Controller" }
           );

            routes.MapRoute(
               name: "categoryProduct",
               url: "san-pham/{metatitle}-{id}",
               defaults: new { controller = "SanPham", action = "ChiTietSanPham", id = UrlParameter.Optional },
               namespaces: new[] { "ShopColor.Controller" }
           );
        }
    }
}
