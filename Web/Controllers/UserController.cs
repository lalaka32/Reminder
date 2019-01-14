using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.UserModels;

namespace Web.Controllers
{
	public class UserController : Controller
	{
		IUserService _userService;

		public UserController(IUserService userService, IRoleService roleService)
		{
			_userService = userService;
		}

		[Authorize(Roles ="Admin, Moderator")]
		public ActionResult Index()
		{
			var u = _userService.GetAllUsers();
			return View(_userService.GetAllUsers());
		}

		[Authorize(Roles = "Admin, Moderator")]
		public ActionResult Details(int id)
		{
			return View(_userService.Read(id));
		}

		[Authorize(Roles = "Admin, Moderator")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: User/Create
		[HttpPost]
		public ActionResult Create(CreateUser createUser)
		{
			if (ModelState.IsValid)
			{
				User user = new User()
				{
					Id = createUser.Id,
					Email = createUser.Email,
					Login = createUser.Login,
					Password = createUser.Password,
					Role = new Entities.Concrete.Role()
					{
						Id = createUser.RoleId
					},
					UserName = createUser.UserName
				};
				_userService.Create(user);
				
				return RedirectToAction("Index");
			}

			return View(createUser);
		}

		[Authorize(Roles = "Admin, Moderator")]
		public ActionResult Edit(int id)
		{
			return View(_userService.Read(id));
		}

		// POST: User/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, CreateUser createUser)
		{
			if (ModelState.IsValid)
			{
				User user = new User()
				{
					Id = id,
					Email = createUser.Email,
					Login = createUser.Login,
					Password = createUser.Password,
					Role = new Entities.Concrete.Role()
					{
						Id = createUser.RoleId
					},
					UserName = createUser.UserName
				};
				_userService.Update(user);

				return RedirectToAction("Index");
			}
			return View(createUser);
		}

		[Authorize(Roles = "Admin, Moderator")]
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
