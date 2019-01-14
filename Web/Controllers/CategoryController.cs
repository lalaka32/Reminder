using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
		ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[OutputCache(Location = OutputCacheLocation.None)]
		[Authorize]
		public ActionResult GetAll()
		{
			return Json(_categoryService.GetAllCategories(), JsonRequestBehavior.AllowGet);
		}
	}
}