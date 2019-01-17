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

		[Authorize(Roles = "Admin, Moderator")]
		public ActionResult Index()
		{
			var u = _userService.GetAllUsers();
			return View(MapOnViewModel(_userService.GetAllUsers()));
		}

		[Authorize(Roles = "Admin, Moderator")]
		public ActionResult Details(int id)
		{
			return View(MapOnViewModel(_userService.Read(id)));
		}

		[Authorize(Roles = "Admin, Moderator")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: User/Create
		[HttpPost]
		public ActionResult Create(CreateUserViewModel createUser)
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
				var info = _userService.Create(user);

				if (info.Successed)
				{
					return RedirectToAction("Index");
				}

				ModelState.AddModelError(info.Property, info.Message);
			}

			return View(createUser);
		}

		[Authorize(Roles = "Admin, Moderator")]
		public ActionResult Edit(int id)
		{
			return View(MapOnCreateUser(_userService.Read(id)));
		}

		// POST: User/Edit/5
		[HttpPost]
		public ActionResult Edit(CreateUserViewModel createUser)
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
				var info = _userService.Update(user);

				if (info.Successed)
				{
					return RedirectToAction("Index");
				}

				ModelState.AddModelError(info.Property, info.Message);
			}
			return View(createUser);
		}

		[Authorize(Roles = "Admin, Moderator")]
		public ActionResult Delete(int id)
		{
			return View(MapOnViewModel(_userService.Read(id)));
		}

		// POST: User/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			_userService.Delete(id);

			return RedirectToAction("Index");
		}

		CreateUserViewModel MapOnCreateUser(User user)
		{
			return new CreateUserViewModel()
			{
				Id = user.Id,
				Email = user.Email,
				Login = user.Login,
				Password = user.Password,
				RoleId = user.Role.Id,
				UserName = user.UserName
			};
		}

		UserViewModel MapOnViewModel(User user)
		{
			return new UserViewModel()
			{
				Id = user.Id,
				Email = user.Email,
				Login = user.Login,
				Password = user.Password,
				Role = user.Role.Name,
				UserName = user.UserName
			};
		}

		IEnumerable<UserViewModel> MapOnViewModel(IEnumerable<User> users)
		{
			List<UserViewModel> models = new List<UserViewModel>();

			foreach (var user in users)
			{
				models.Add(MapOnViewModel(user));
			}

			return models;
		}
	}
}
