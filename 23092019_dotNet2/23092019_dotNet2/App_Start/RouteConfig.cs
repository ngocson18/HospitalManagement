using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _23092019_dotNet2
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

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Login"}
            );

            routes.MapRoute(
                name: "Login2",
                url: "{controller}/{action}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Forgotpassword",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "ForgotPassword", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "UserGroup",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Group", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_User", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Doctor",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Doctor", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ServiceUnit",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_ServiceUnit", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Office",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Office", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Specialize",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Specialize", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Customer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Customer", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ScheduleList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Schedule", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MissList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Miss", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TreatmentList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Treatment", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DoneList",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Done", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Payment",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Payment", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Debt",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Debt", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Productcategory",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_ProductCategory", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "tbl_Product", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ImportProduct",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "tbl_ImportProduct", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "ExportProduct",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "tbl_ExportProduct", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Search",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "tbl_User", action = "Search", id = UrlParameter.Optional }
           );
        }
    }
}
