using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodingBlog.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Admin", //Route name
                "cb-admin", //URL with parameters
                new { controller = "Admin", action = "Index" } //Parameters defaults
                );

            routes.MapRoute(
                "PostsListPerTag", //Route name
                "Tag/{Tag}", //URL with parameters
                new { controller = "Post", action = "ListPerTag" } //Parameters defaults
                );

            routes.MapRoute(
                "PostDetailsByDateAndName", //Route name
                "{Year}/{Month}/{Day}/{PostName}", //URL with parameters
                new { controller = "Post", action = "Details", },
                new { Year = @"\d{4}", Month = @"\d{2}", Day = @"\d{2}" }//Parameters defaults
                );

            routes.MapRoute(
                "Default", //Route name
                "{Year}/{Month}/{Day}", //URL with parameters
                new { controller = "Post", action = "List", 
                    Year = UrlParameter.Optional, 
                    Month = UrlParameter.Optional,
                    Day = UrlParameter.Optional }//Parameters defaults
                );
        }
    }
}