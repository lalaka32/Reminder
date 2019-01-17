using DAL.Data.Interfaces;
using DAL.Helpers.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Concrete
{
	public class ActionRepository : IActionRepository
	{

		readonly IConnectionHelper _helper;

		public ActionRepository(IConnectionHelper helper)
		{
			_helper = helper;
		}

		public void Create(ReminderAction data)
		{
			_helper.CreateConnection()
				.CreateCommand(DbConstants.CREATE_ACTION)
				.AddParameter(_helper.CreateParameter("ReminderId", data.IdReminder))
				.AddParameter(_helper.CreateParameter("Description", data.Description))
				.ExecuteQuery();
		}

		public void Delete(int? id)
		{

			_helper.CreateConnection()
				.CreateCommand(DbConstants.DELETE_ACTION)
				.AddParameter(_helper.CreateParameter("Id", id))
				.ExecuteQuery();
		}

		public IEnumerable<ReminderAction> GetActionsByReminderId(int reminderId)
		{
			List<ReminderAction> allActions = new List<ReminderAction>();

			var reader = _helper.CreateConnection()
				.CreateCommand(DbConstants.GET_ACTION_BY_REMINDER_ID)
				.AddParameter(_helper.CreateParameter("ReminderId", reminderId))
				.ExecuteReader();

			foreach (var item in reader)
			{
				var action = ConvertDataToClass(item);

				allActions.Add(action);
			}

			return allActions;
		}

		public IReadOnlyCollection<ReminderAction> GetAll()
		{
			List<ReminderAction> allActions = new List<ReminderAction>();

			var reader = _helper.CreateConnection()
				.CreateCommand(DbConstants.GET_ALL_ACTIONS)
				.ExecuteReader();

			foreach (var item in reader)
			{
				var action = ConvertDataToClass(item);

				allActions.Add(action);
			}

			return allActions;
		}

		public ReminderAction Read(int? id)
		{
			ReminderAction action = null;

			var reader = _helper.CreateConnection()
				.CreateCommand(DbConstants.GET_ACTION_BY_ID)
				.AddParameter(_helper.CreateParameter("Id", id))
				.ExecuteReader();

			foreach (var item in reader)
			{
				action = ConvertDataToClass(item);
			}

			return action;
		}

		public void Update(ReminderAction data)
		{
			_helper.CreateConnection()
				.CreateCommand(DbConstants.UPDATE_ACTION)
				.AddParameter(_helper.CreateParameter("Id", data.Id, DbType.Int32))
				.AddParameter(_helper.CreateParameter("ReminderId", data.IdReminder))
				.AddParameter(_helper.CreateParameter("Description", data.Description))
				.ExecuteQuery();
		}

		private ReminderAction ConvertDataToClass(IDataRecord data)
		{
			ReminderAction action = new ReminderAction()
			{
				Id = (int)data["Id"],
				IdReminder = (int)data["ReminderId"],
				Description = (string)data["Description"],
			};
			return action;
		}
	}
}
