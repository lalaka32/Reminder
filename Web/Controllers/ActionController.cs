using BLL.Services.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.ReminderAction;

namespace Web.Controllers
{
	public class ActionController : Controller
	{
		IActionService _actionService;

		public ActionController(IActionService actionService)
		{
			_actionService = actionService;
		}

		// GET: Action
		[Authorize]
		public ActionResult Index(int reminderId)
		{
			var actions = _actionService.GetActionsByReminderId(reminderId);
			ViewBag.reminderId = reminderId;
			return View(Map(actions));
		}

		[Authorize]
		public ActionResult Details(int id)
		{
			var action = _actionService.Read(id);
			return View(Map(action));
		}

		[Authorize]
		public ActionResult Create(int reminderId)
		{
			ReminderActionViewModel viewModel = new ReminderActionViewModel()
			{
				IdReminder = reminderId
			};
			return View(viewModel);
		}

		// POST: Action/Create
		[HttpPost]
		public ActionResult Create(ReminderActionViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				ReminderAction action = new ReminderAction()
				{
					Id = viewModel.Id,
					IdReminder = viewModel.IdReminder,
					Description = viewModel.Description
				};
				_actionService.Create(action);
				return RedirectToAction("Index", "Action", new { reminderId = viewModel.IdReminder });
			}

			return View(viewModel);
		}

		[Authorize]
		public ActionResult Edit(int id)
		{
			var action = _actionService.Read(id);
			return View(Map(action));
		}

		// POST: Action/Edit/5
		[HttpPost]
		public ActionResult Edit(ReminderActionViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				ReminderAction action = new ReminderAction()
				{
					Id = viewModel.Id,
					IdReminder = viewModel.IdReminder,
					Description = viewModel.Description
				};
				_actionService.Update(action);
				return RedirectToAction("Index", "Action", new { reminderId = viewModel.IdReminder });
			}

			return View(viewModel);
		}

		[Authorize]
		public ActionResult Delete(int id)
		{
			var action = _actionService.Read(id);
			return View(Map(action));
		}

		// POST: Action/Delete/5
		[HttpPost]
		public ActionResult Delete(ReminderActionViewModel viewModel)
		{
			_actionService.Delete(viewModel.Id);
			return RedirectToAction("Index", "Action", new { reminderId = viewModel.IdReminder });
		}

		ReminderActionViewModel Map(ReminderAction reminderAction)
		{
			ReminderActionViewModel viewModel = new ReminderActionViewModel()
			{
				Id = reminderAction.Id,
				Description = reminderAction.Description,
				IdReminder = reminderAction.IdReminder
			};
			return viewModel;
		}
		IEnumerable<ReminderActionViewModel> Map(IEnumerable<ReminderAction> reminderAction)
		{
			List<ReminderActionViewModel> reminderActionViewModels = new List<ReminderActionViewModel>();
			foreach (var item in reminderAction)
			{
				reminderActionViewModels.Add(Map(item));
			}
			return reminderActionViewModels;
		}
	}
}
