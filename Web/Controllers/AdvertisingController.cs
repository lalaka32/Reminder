using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AdvertisingController : Controller
    {

		IAdvertisingService _advertisingService;

		public AdvertisingController(IAdvertisingService advertisingService)
		{
			_advertisingService = advertisingService;
		}

        [ChildActionOnly]
        public ActionResult Index()
        {
            return PartialView(_advertisingService.GetAdvertising());
        }
    }
}