using BLL.Services.Interfaces;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Account;
using Web.Models.UserModels;

namespace Web.Controllers
{
	public class AccountController : Controller
	{
		IAuthorizationService _authorizationService;
		IUserService _userService;

		public AccountController(IAuthorizationService authorizationService, IUserService userService)
		{
			_authorizationService = authorizationService;
			_userService = userService;
		}

		[Authorize]
		public ActionResult Logout()
		{
			_authorizationService.Logout();
			return RedirectToAction("Index", "Home");
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				var operation = _authorizationService.Authenticate(model.Login, model.Password);

				if (!operation.Successed)
				{
					ModelState.AddModelError(operation.Property, operation.Message);
					return View(model);
				}
				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}
		public ActionResult Register()
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Register(RegisteryModel model)
		{
			if (ModelState.IsValid)
			{
				User user = new User()
				{
					UserName = model.UserName,
					Email = model.Email,
					Login = model.Login,
					Password = model.Password
				};

				var operation = _authorizationService.Register(user);
				if (!operation.Successed)
				{
					ModelState.AddModelError(operation.Property, operation.Message);
					return View(model);
				}
				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[Authorize]
		public ActionResult UserProfile(string login)
		{
			var user = _userService.GetUserByLogin(login);
			ProfileViewModel viewModel = new ProfileViewModel()
			{
				Id = user.Id,
				Email = user.Email,
				Login = user.Login,
				Password = user.Password,
				UserName = user.UserName
			};
			return View(viewModel);
		}

		[Authorize]
		public ActionResult EditProfile(string login)
		{
			var user = _userService.GetUserByLogin(login);
			ProfileViewModel viewModel = new ProfileViewModel()
			{
				Id = user.Id,
				Email = user.Email,
				Login = user.Login,
				Password = user.Password,
				UserName = user.UserName,
				RoleId = user.Role.Id
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditProfile(ProfileViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = new User()
				{
					UserName = model.UserName,
					Email = model.Email,
					Login = model.Login,
					Password = model.Password,
					Id = model.Id,
					Role = new Role()
					{
						Id = model.RoleId
					}
				};
				var operation = _authorizationService.EditProfile(user);
				if (operation.Successed)
				{
					Logout();
					Login(new LoginModel() { Login = user.Login, Password = user.Password });
					return RedirectToAction("UserProfile", "Account", new { login = model.Login });
				}
				ModelState.AddModelError(operation.Property, operation.Message);
			}

			return View(model);
		}


	}
}