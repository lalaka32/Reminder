using DAL.Data.Interfaces;
using DAL.Helpers.Interfaces;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Concrete
{
	class ReminderReporitory : IReminderRepository
	{

		readonly IConnectionHelper _query;

		public ReminderReporitory(IConnectionHelper query)
		{
			_query = query;
		}

		public IEnumerable<Reminder> GetRemindersByLogin(string login)
		{
			List<Reminder> reminders = new List<Reminder>();

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_REMINDER_BY_LOGIN)
				.AddParameter(_query.CreateParameter("Login", login))
				.ExecuteReader();

			foreach (var item in reader)
			{
				var reminder = ConvertDataToClass(item);

				reminders.Add(reminder);
			}

			return reminders;
		}

		private Reminder ConvertDataToClass(IDataRecord data)
		{
			Reminder rem = new Reminder()
			{
				Id = (int)data["Id"],
				Category = new CategoryOfReminder()
				{
					Id = (int)data["CategoryId"],
					Name = (string)data["Category"]
				},
				Name = (string)data["Name"],
				State = new StateOfReminder()
				{
					Id = (int)data["StateId"],
					Name = (string)data["State"]
				},
				Picture = data["Picture"].GetType() == System.DBNull.Value.GetType() ? new byte[0] : (byte[])data["Picture"],
				Description = (string)data["Description"],
				DateOfCreation = (DateTime)data["DateOfCreation"],
				DateOfEvent = (DateTime)data["DateOfEvent"],
				User = new User
				{
					Id = (int)data["UserId"],
					Email = (string)data["Email"],
					UserName = (string)data["UserName"],
					Login = (string)data["Login"],
					Password = (string)data["Password"],
					Role = new Role()
					{
						Id = (int)data["RoleId"],
						Name = (string)data["RoleName"]
					}
				}
			};


			return rem;
		}

		public void Create(Reminder data)
		{
			IDataParameter pictureParametr = null;
			if (data.Picture == null)
			{
				pictureParametr = _query.CreateParameter("Picture", DBNull.Value,DbType.Binary);
			}
			else
			{

				pictureParametr = _query.CreateParameter("Picture", data.Picture);
			}

			_query.CreateConnection()
				.CreateCommand(DbConstants.CREATE_REMINDER)
				.AddParameter(_query.CreateParameter("UserId", data.User.Id))
				.AddParameter(_query.CreateParameter("StateId", data.State.Id))
				.AddParameter(_query.CreateParameter("CategoryId", data.Category.Id))
				.AddParameter(_query.CreateParameter("Name", data.Name))
				.AddParameter(_query.CreateParameter("Description", data.Description))
				.AddParameter(_query.CreateParameter("DateOfCreation", data.DateOfCreation))
				.AddParameter(_query.CreateParameter("DateOfEvent", data.DateOfEvent))
				.AddParameter(pictureParametr)
				.ExecuteQuery();
		}

		public void Delete(int? id)
		{

			_query.CreateConnection()
				.CreateCommand(DbConstants.DELETE_REMINDER)
				.AddParameter(_query.CreateParameter("Id", id))
				.ExecuteQuery();
		}

		public IReadOnlyCollection<Reminder> GetAll()
		{
			List<Reminder> reminders = new List<Reminder>();


			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_ALL_REMINDERS)
				.ExecuteReader();

			foreach (var item in reader)
			{
				var reminder = ConvertDataToClass(item);

				reminders.Add(reminder);
			}

			return reminders;
		}

		public Reminder Read(int? id)
		{
			Reminder reminder = null;

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_REMINDER_BY_ID)
				.AddParameter(_query.CreateParameter("Id", id))
				.ExecuteReader();

			foreach (var item in reader)
			{
				reminder = ConvertDataToClass(item);
			}
			return reminder;
		}

		public void Update(Reminder data)
		{
			IDataParameter pictureParametr = null;
			if (data.Picture == null)
			{
				pictureParametr = _query.CreateParameter("Picture", DBNull.Value, DbType.Binary);
			}
			else
			{

				pictureParametr = _query.CreateParameter("Picture", data.Picture);
			}

			_query.CreateConnection()
				.CreateCommand(DbConstants.UPDATE_REMINDER)
				.AddParameter(_query.CreateParameter("Id", data.Id))
				.AddParameter(_query.CreateParameter("UserId", data.User.Id))
				.AddParameter(_query.CreateParameter("StateId", data.State.Id))
				.AddParameter(_query.CreateParameter("CategoryId", data.Category.Id))
				.AddParameter(_query.CreateParameter("Name", data.Name))
				.AddParameter(_query.CreateParameter("Description", data.Description))
				.AddParameter(_query.CreateParameter("DateOfCreation", data.DateOfCreation))
				.AddParameter(_query.CreateParameter("DateOfEvent", data.DateOfEvent))
				.AddParameter(pictureParametr)
				.ExecuteQuery();
		}
	}
}
