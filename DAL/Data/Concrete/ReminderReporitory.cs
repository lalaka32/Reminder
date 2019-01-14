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

			var idParameter = _query.CreateParameter("Login", login);

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_REMINDER_BY_LOGIN)
				.AddParameter(idParameter)
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
			var IdUserParameter = _query.CreateParameter("UserId", data.User.Id);
			var IdStateParameter = _query.CreateParameter("StateId", data.State.Id);
			var IdCategoryParameter = _query.CreateParameter("CategoryId", data.Category.Id);
			var nameParameter = _query.CreateParameter("Name", data.Name);
			var desctiptionParametr = _query.CreateParameter("Description", data.Description);
			var dateOfCreationParameter = _query.CreateParameter("DateOfCreation", data.DateOfCreation);
			var dateOfEventParameter = _query.CreateParameter("DateOfEvent", data.DateOfEvent);
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
				.AddParameter(IdUserParameter)
				.AddParameter(IdStateParameter)
				.AddParameter(IdCategoryParameter)
				.AddParameter(nameParameter)
				.AddParameter(desctiptionParametr)
				.AddParameter(dateOfCreationParameter)
				.AddParameter(dateOfEventParameter)
				.AddParameter(pictureParametr)
				.ExecuteQuery();
		}

		public void Delete(int? id)
		{
			var idParameter = _query.CreateParameter("Id", id);

			_query.CreateConnection()
				.CreateCommand(DbConstants.DELETE_REMINDER)
				.AddParameter(idParameter)
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

			var idParameter = _query.CreateParameter("Id", id);

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_REMINDER_BY_ID)
				.AddParameter(idParameter)
				.ExecuteReader();

			foreach (var item in reader)
			{
				reminder = ConvertDataToClass(item);
			}
			return reminder;
		}

		public void Update(Reminder data)
		{
			var IdParameter = _query.CreateParameter("Id", data.Id);
			var IdUserParameter = _query.CreateParameter("UserId", data.User.Id);
			var IdStateParameter = _query.CreateParameter("StateId", data.State.Id);
			var IdCategoryParameter = _query.CreateParameter("CategoryId", data.Category.Id);
			var nameParameter = _query.CreateParameter("Name", data.Name);
			var desctiptionParametr = _query.CreateParameter("Description", data.Description);
			var dateOfCreationParameter = _query.CreateParameter("DateOfCreation", data.DateOfCreation);
			var dateOfEventParameter = _query.CreateParameter("DateOfEvent", data.DateOfEvent);
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
				.AddParameter(IdParameter)
				.AddParameter(IdUserParameter)
				.AddParameter(IdStateParameter)
				.AddParameter(IdCategoryParameter)
				.AddParameter(nameParameter)
				.AddParameter(desctiptionParametr)
				.AddParameter(dateOfCreationParameter)
				.AddParameter(dateOfEventParameter)
				.AddParameter(pictureParametr)
				.ExecuteQuery();
		}
	}
}
