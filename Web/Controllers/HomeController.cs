using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
	public class HomeController : Controller
	{
		//IAdvertisingService _advertisingService;
		//public HomeController(IAdvertisingService advertisingService)
		//{
		//	_advertisingService = advertisingService;
		//}
		public ActionResult Index()
		{
			//ViewBag.Advert = _advertisingService.GetAdvertising();
			return View();
		}
		
		public ActionResult About()
		{
			ViewBag.Message = "Description.";

			return View();
		}

		[Authorize]
		public ActionResult Contact()
		{
			ViewBag.Message = "Contact.";

			return View();
		}
	}
}