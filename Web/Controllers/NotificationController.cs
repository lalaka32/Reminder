using BLL.Services.Abstract;
using BLL.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Logger;
using log4net;

namespace Web.Controllers
{
    public class NotificationController : Controller
    {
		INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
        // GET: Notification
        public ActionResult All()
        {
            return View(_notificationService.GetAllNotifications);
        }
		ILog log;
		public void FakePage()
		{
			log = Logger.For(this);
			log.Fatal("Security failed.");
		}
	}
}
