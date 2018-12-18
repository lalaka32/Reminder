using BLL.Services.Abstract;
using Entities;
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
		public ActionResult Index()
		{
			return View(_userService.GetAllUsers);
		}

		// GET: User/Details/5
		public ActionResult Details(int id)
		{
			return View(_userService.Read(id));
		}

		// GET: User/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: User/Create
		[HttpPost]
		public ActionResult Create(User user)
		{
			_userService.Create(user);
			return RedirectToAction("Index");
		}

		// GET: User/Edit/5
		public ActionResult Edit(int id)
		{
			return View(_userService.Read(id));
		}

		// POST: User/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, User user)
		{

			user.Id = id;
			_userService.Update(user);

			return RedirectToAction("Index");

		}

		// GET: User/Delete/5
		public ActionResult Delete(int id)
		{
			return View((_userService.Read(id)));
		}

		// POST: User/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{

			_userService.Delete(id);

			return RedirectToAction("Index");

		}
	}
}
