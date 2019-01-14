using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Web.Controllers
{
    public class RoleController : Controller
    {
		IRoleService _roleService;	
		public RoleController(IRoleService roleService)
		{
			_roleService = roleService;
		}

		[OutputCache(Location = OutputCacheLocation.None)]
		[Authorize]
		public ActionResult GetAll()
        {
			return Json(_roleService.GetAllRoles(), JsonRequestBehavior.AllowGet);
		}
    }
}