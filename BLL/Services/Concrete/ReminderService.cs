using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
	public class ReminderService : IReminderService
	{
		IReminderRepository _reminderRepository;
		IStateRepository _stateRepository;

		public ReminderService(IReminderRepository notificationRepository, IStateRepository stateRepository)
		{
			_reminderRepository = notificationRepository;
			_stateRepository = stateRepository;
		}

		public void Create(Reminder data)
		{
			if (data == null)
			{
				return;
			}
			_reminderRepository.Create(SetStateToReminder(data));
		}

		public void Delete(int? id)
		{
			if (id == null || id < 1)
			{
				return;
			}
			_reminderRepository.Delete(id);
		}

		public IEnumerable<Reminder> GetRemindersByCategoryId(IEnumerable<Reminder> reminders, int? id)
		{
			if (id != null || id < 1)
			{
				return reminders.Where(x => x.Category.Id == id);
			}
			return reminders;
		}

		public IEnumerable<Reminder> GetRemindersByDate(IEnumerable<Reminder> reminders, DateTime? date)
		{
			if (date != null)
			{
				return reminders.Where(x => x.DateOfEvent.Date.Year == date.Value.Date.Year &&
				x.DateOfEvent.Date.Month == date.Value.Month &&
				x.DateOfEvent.Day == date.Value.Day);
			}
			return reminders;
		}

		public IEnumerable<Reminder> GetRemindersByName(IEnumerable<Reminder> reminders, string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				return reminders.Where(x => x.Name.ToLower().Contains(name.Trim().ToLower()));
			}
			return reminders;
		}

		public IEnumerable<Reminder> GetUserReminders(string login)
		{
			return string.IsNullOrEmpty(login) ? null : SetStateToReminder(_reminderRepository.GetRemindersByLogin(login));
		}

		public Reminder Read(int? id)
		{
			if (id == null || id < 1)
			{
				return null;
			}
			return SetStateToReminder(_reminderRepository.Read(id));
		}

		public IEnumerable<Reminder> SearchUserReminders(string login, string name, int? categoryId, DateTime? date)
		{
			var result = GetUserReminders(login);
			result = GetRemindersByName(result, name);
			result = GetRemindersByDate(result, date);
			result = GetRemindersByCategoryId(result, categoryId);

			return SetStateToReminder(result);
		}

		public void Update(Reminder data)
		{
			if (data == null)
			{
				return;
			}
			data.State = _stateRepository.GetAll().Single(x => x.Name == "Deferred");
			_reminderRepository.Update(SetStateToReminder(data));
		}

		Reminder SetStateToReminder(Reminder data)
		{
			if (data.DateOfEvent > DateTime.Now && data.State?.Name != "Deferred")
			{
				data.State = _stateRepository.GetAll().Single(x => x.Name == "Planned");
			}
			else if (data.DateOfEvent <= DateTime.Now)
			{
				data.State = _stateRepository.GetAll().Single(x => x.Name == "Completed");
			}
			return data;
		}

		IEnumerable<Reminder> SetStateToReminder(IEnumerable<Reminder> data)
		{
			foreach (var item in data)
			{
				SetStateToReminder(item);
			}
			return data;
		}
	}
}
