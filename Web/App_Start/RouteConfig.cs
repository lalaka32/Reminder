using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "UserReminders",
				url: "userReminders",
				defaults: new { controller = "Reminder", action = "ListJson" }
			);

			routes.MapRoute(
				name: "Roles",
				url: "roles",
				defaults: new { controller = "Role", action = "GetAll" }
			);

			routes.MapRoute(
				name: "Categories",
				url: "categories",
				defaults: new { controller = "Category", action = "GetAll" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
