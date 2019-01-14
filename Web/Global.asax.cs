using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		public override void Init()
		{
			base.Init();
			base.PostAuthenticateRequest += OnAuthenticateRequest;
		}

		private void OnAuthenticateRequest(object sender, EventArgs eventArgs)
		{
			if (HttpContext.Current.User.Identity.IsAuthenticated)
			{
				var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
				var decodedTicket = FormsAuthentication.Decrypt(cookie.Value);
				var role = new string[] { decodedTicket.UserData };

				var principal = new GenericPrincipal(HttpContext.Current.User.Identity, role);
				HttpContext.Current.User = principal;
			}
		}
	}

	
}
