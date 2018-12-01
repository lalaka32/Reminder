using BLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserController : Controller
    {
		IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}
        // GET: User
        public ActionResult All()
        {
            return View(_userService.GetAllUsers);
        }
		
    }
}
