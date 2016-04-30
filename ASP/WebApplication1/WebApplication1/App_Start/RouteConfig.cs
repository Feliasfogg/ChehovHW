using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1 {
   //Этот класс определяет как обрабатывать http запрос
   public class RouteConfig {
      public static void RegisterRoutes(RouteCollection routes) {
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}", //имя контроллера/имя действия/айди контроллера
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
      }
   }
}