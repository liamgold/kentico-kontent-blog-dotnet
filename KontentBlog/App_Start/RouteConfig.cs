using System.Web.Mvc;
using System.Web.Routing;

namespace KontentBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.AppendTrailingSlash = true;

            routes.MapRoute(
                name: "BlogTags",
                url: "blog/tag/{tagCode}",
                defaults: new { controller = "Blog", action = "Tag" }
            );

            routes.MapRoute(
                name: "BlogPost",
                url: "blog/{urlSlug}",
                defaults: new { controller = "Blog", action = "Post" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
