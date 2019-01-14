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

		readonly IConnectionHelper _query;

		public ActionRepository(IConnectionHelper query)
		{
			_query = query;
		}

		public void Create(ReminderAction data)
		{
			var idReminderParameter = _query.CreateParameter("ReminderId", data.IdReminder);
			var descriptionParameter = _query.CreateParameter("Description", data.Description);

			_query.CreateConnection()
				.CreateCommand(DbConstants.CREATE_ACTION)
				.AddParameter(idReminderParameter)
				.AddParameter(descriptionParameter)
				.ExecuteQuery();
		}

		public void Delete(int? id)
		{
			var idParameter = _query.CreateParameter("Id", id);

			_query.CreateConnection()
				.CreateCommand(DbConstants.DELETE_ACTION)
				.AddParameter(idParameter)
				.ExecuteQuery();
		}

		public IEnumerable<ReminderAction> GetActionsByReminderId(int reminderId)
		{
			List<ReminderAction> allActions = new List<ReminderAction>();
			var reminderIdParameter = _query.CreateParameter("ReminderId", reminderId);

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_ACTION_BY_REMINDER_ID)
				.AddParameter(reminderIdParameter)
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

			var reader = _query.CreateConnection()
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

			var idParameter = _query.CreateParameter("Id", id);

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_ACTION_BY_ID)
				.AddParameter(idParameter)
				.ExecuteReader();

			foreach (var item in reader)
			{
				action = ConvertDataToClass(item);
			}

			return action;
		}

		public void Update(ReminderAction data)
		{
			var idParameter = _query.CreateParameter("Id", data.Id, DbType.Int32);
			var reminderIdParameter = _query.CreateParameter("ReminderId", data.IdReminder);
			var descriptionParameter = _query.CreateParameter("Description", data.Description);
			_query.CreateConnection()
				.CreateCommand(DbConstants.UPDATE_ACTION)
				.AddParameter(idParameter)
				.AddParameter(reminderIdParameter)
				.AddParameter(descriptionParameter)
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
