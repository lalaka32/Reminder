using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models.Reminder;
using Entities;
using System.Web.UI;
using System.Web;
using System.IO;

namespace Web.Controllers
{
	public class ReminderController : Controller
	{
		IReminderService _reminderService;
		IUserService _userService;

		public ReminderController(IReminderService notificationService, IUserService userService)
		{
			_reminderService = notificationService;
			_userService = userService;
		}

		[Authorize]
		public ActionResult List(string login)
		{
			ViewBag.login = login;
			ViewBag.userName = _userService.GetUserByLogin(login)?.UserName;
			var list = _reminderService.GetUserReminders(login)?.OrderBy(x => x.DateOfEvent);
			return View(Map(list));
		}

		IEnumerable<ReminderViewModel> Map(IEnumerable<Reminder> reminders)
		{
			if (reminders == null)
			{
				return new List<ReminderViewModel>();
			}
			List<ReminderViewModel> list = new List<ReminderViewModel>();
			foreach (var item in reminders)
			{
				list.Add(Map(item));
			}
			return list;

		}

		ReminderViewModel Map(Reminder reminder)
		{
			if (reminder == null)
			{
				throw new ArgumentNullException(nameof(reminder));
			}
			return new ReminderViewModel()
			{
				Id = reminder.Id,
				Name = reminder.Name,
				Category = reminder.Category,
				DateOfCreation = reminder.DateOfCreation,
				DateOfEvent = reminder.DateOfEvent,
				Description = reminder.Description,
				Picture = reminder.Picture,
				State = reminder.State,
				User = reminder.User,
			};

		}

		[Authorize]
		public ActionResult Create(string login)
		{
			var user = _userService.GetUserByLogin(login);
			CreateReminderModel model = new CreateReminderModel()
			{
				DateOfEvent = DateTime.Now,
				TimeOfEvent = DateTime.Now,
				Login = login,
				UserName = user.UserName
			};
			return View(model);
		}

		[Authorize]
		[HttpPost]
		public ActionResult Create(CreateReminderModel model, HttpPostedFileBase uploadImage)
		{
			if (ModelState.IsValid)
			{
				var user = _userService.GetUserByLogin(model.Login);

				Reminder reminder = new Reminder()
				{
					User = user,
					Name = model.Name,
					Description = model.Description,
					Category = new CategoryOfReminder()
					{
						Id = model.CategoryId
					},
					Picture = model.Picture,
					DateOfCreation = DateTime.Now,
					DateOfEvent = model.DateOfEvent
				};
				reminder.DateOfEvent = reminder.DateOfEvent.AddHours(model.TimeOfEvent.Hour);
				reminder.DateOfEvent = reminder.DateOfEvent.AddMinutes(model.TimeOfEvent.Minute);

				if (uploadImage != null)
				{
					byte[] imageData = null;
					// считываем переданный файл в массив байтов
					using (var binaryReader = new BinaryReader(uploadImage.InputStream))
					{
						imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
					}
					reminder.Picture = imageData;
				}

				_reminderService.Create(reminder);
				return RedirectToAction("List", "Reminder", new { login = model.Login });
			}

			return View(model);
		}

		[Authorize]
		public ActionResult Delete(int? Id)
		{

			return View(Map(_reminderService.Read(Id)));
		}

		[Authorize]
		[HttpPost]
		public ActionResult Delete(ReminderViewModel reminder)
		{
			_reminderService.Delete(reminder.Id);

			return RedirectToAction("List", "Reminder", new { login = reminder.User.Login });
		}

		[Authorize]
		public ActionResult Details(int id)
		{
			return View(Map(_reminderService.Read(id)));
		}

		[Authorize]
		public ActionResult Edit(int id)
		{
			var reminder = _reminderService.Read(id);
			CreateReminderModel model = new CreateReminderModel()
			{
				Id = reminder.Id,
				Name = reminder.Name,
				CategoryId = reminder.Category.Id,
				DateOfCreation = reminder.DateOfCreation,
				DateOfEvent = reminder.DateOfEvent.Date,
				Description = reminder.Description,
				Login = reminder.User.Login,
				Picture = reminder.Picture,
				TimeOfEvent = reminder.DateOfEvent,
				UserName = reminder.User.UserName
			};
			return View(model);
		}

		// POST: Action/Edit/5
		[HttpPost]
		public ActionResult Edit(CreateReminderModel viewModel, HttpPostedFileBase uploadImage)
		{
			Reminder reminder = null;

			if (uploadImage != null)
			{
				byte[] imageData = null;
				// считываем переданный файл в массив байтов
				using (var binaryReader = new BinaryReader(uploadImage.InputStream))
				{
					imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
				}
				viewModel.Picture = imageData;
			}
			else
			{
				viewModel.Picture = _reminderService.Read(viewModel.Id).Picture;
			}

			if (ModelState.IsValid)
			{
				var user = _userService.GetUserByLogin(viewModel.Login);

				reminder = new Reminder()
				{
					Id = viewModel.Id,
					User = user,
					Name = viewModel.Name,
					Description = viewModel.Description,
					Category = new CategoryOfReminder()
					{
						Id = viewModel.CategoryId
					},
					Picture = viewModel.Picture,
					DateOfCreation = DateTime.Now,
					DateOfEvent = viewModel.DateOfEvent

				};
				reminder.DateOfEvent = reminder.DateOfEvent.AddHours(viewModel.TimeOfEvent.Hour);
				reminder.DateOfEvent = reminder.DateOfEvent.AddMinutes(viewModel.TimeOfEvent.Minute);

				_reminderService.Update(reminder);
				return RedirectToAction("List", "Reminder", new { login = viewModel.Login });
			}

			return View(viewModel);
		}


		[OutputCache(Location = OutputCacheLocation.None)]
		[Authorize]
		public ActionResult ListJson(string login)
		{
			return Json(Map(_reminderService.GetUserReminders(login).OrderBy(x => x.DateOfEvent)), JsonRequestBehavior.AllowGet);
		}

		[OutputCache(Location = OutputCacheLocation.None)]
		[Authorize]
		public ActionResult ListJsonSearch(string login, string name, int? categoryId, string date)
		{
			DateTime? dateOfEvent = null;
			if (!string.IsNullOrEmpty(date))
			{
				dateOfEvent = DateTime.Parse(date);
			}
			var filtered = _reminderService.SearchUserReminders(login, name, categoryId, dateOfEvent).OrderBy(x => x.DateOfEvent);

			return Json(Map(filtered), JsonRequestBehavior.AllowGet);
		}

	}
}
