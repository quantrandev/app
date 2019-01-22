using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VNScience
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DetailPost",
                url: "tin-tuc/{metatitle}-{id}",
                defaults: new { controller = "Post", action = "Detail" },
                namespaces: new[] { "VNScience.Controllers" }
            );

            routes.MapRoute(
                name: "PostCategory",
                url: "danh-muc-tin/{metatitle}-{categoryId}",
                defaults: new { controller = "Post", action = "Index" },
                namespaces: new[] { "VNScience.Controllers" }
            );

            routes.MapRoute(
                name: "SearchPosts",
                url: "tim-kiem/",
                defaults: new { controller = "Post", action = "Search" },
                namespaces: new[] { "VNScience.Controllers" }
            );

            routes.MapRoute(
               name: "Contact",
               url: "lien-he/",
               defaults: new { controller = "Contact", action = "Create" },
               namespaces: new[] { "VNScience.Controllers" }
           );

            routes.MapRoute(
               name: "About",
               url: "gioi-thieu/",
               defaults: new { controller = "About", action = "Index" },
               namespaces: new[] { "VNScience.Controllers" }
           );

            routes.MapRoute(
              name: "DetailNews",
              url: "tin-hoat-dong/{metatitle}-{id}",
              defaults: new { controller = "News", action = "Detail" },
              namespaces: new[] { "VNScience.Controllers" }
          );

            routes.MapRoute(
               name: "News",
               url: "tin-hoat-dong/",
               defaults: new { controller = "News", action = "Index" },
               namespaces: new[] { "VNScience.Controllers" }
           );

            routes.MapRoute(
             name: "RecruitmentDetail",
             url: "tuyen-dung/{metatitle}-{id}",
             defaults: new { controller = "Recruitment", action = "Detail" },
             namespaces: new[] { "VNScience.Controllers" }
         );

            routes.MapRoute(
             name: "Recruitment",
             url: "tuyen-dung/",
             defaults: new { controller = "Recruitment", action = "Index" },
             namespaces: new[] { "VNScience.Controllers" }
         );

            routes.MapRoute(
             name: "ProductList",
             url: "san-pham-giai-phap/{metatitle}-{id}",
             defaults: new { controller = "Product", action = "Index" },
             namespaces: new[] { "VNScience.Controllers" }
         );

            routes.MapRoute(
           name: "CustomerList",
           url: "doi-tac/",
           defaults: new { controller = "Customer", action = "Index" },
           namespaces: new[] { "VNScience.Controllers" }
       );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "VNScience.Controllers" }
            );
        }
    }
}
