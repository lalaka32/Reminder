using DAL.Data.Abstract;
using DAL.SqlHelpers.Abstract;
using Entities;
using System.Collections.Generic;
using System.Data;

namespace DAL.Data.Concrete
{
	class UserRepository : IUserRepository
	{
		readonly ISqlFactory _query;

		public UserRepository(ISqlFactory query)
		{
			_query = query;
		}

		public IReadOnlyCollection<User> GetAll()
		{
			List<User> allUsers = new List<User>();

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_ALL_USERS)
				.ExecuteReader();

			foreach (var item in reader)
			{
				var user = new User
				{
					Id = (int)item["Id"],
					Email = (string)item["Email"],
					Login = (string)item["Login"],
					UserName = (string)item["UserName"],
					Password = (string)item["Password"]
				};

				allUsers.Add(user);
			}

			return allUsers;

		}

		public void Create(User data)
		{
			var loginParameter = _query.CreateParameter("Login", data.Login, DbType.String);
			var passwordParameter = _query.CreateParameter("Password", data.Password, DbType.String);
			var userNameParameter = _query.CreateParameter("UserName", data.UserName, DbType.String);
			var emailParameter = _query.CreateParameter("Email", data.Email, DbType.String);

			_query.CreateConnection()
				.CreateCommand(DbConstants.CREATE_USER)
				.AddParameter(loginParameter)
				.AddParameter(passwordParameter)
				.AddParameter(userNameParameter)
				.AddParameter(emailParameter)
				.ExecuteQuery();
		}

		public void Delete(int? id)
		{
			var idParameter = _query.CreateParameter("Id", id, DbType.Int32);

			_query.CreateConnection()
				.CreateCommand(DbConstants.CREATE_USER)
				.AddParameter(idParameter)
				.ExecuteQuery();
		}

		public User Read(int? id)
		{
			User user = null;

			var idParameter = _query.CreateParameter("id", id, DbType.Int32);

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_USER_BY_ID)
				.AddParameter(idParameter)
				.ExecuteReader();

			foreach (var item in reader)
			{
				user = new User
				{
					Id = (int)item["Id"],
					Email = (string)item["Email"],
					Login = (string)item["Login"],
					UserName = (string)item["UserName"],
					Password = (string)item["Password"]
				};
			}

			return user;
		}

		public void Update(User data)
		{
			var idParameter = _query.CreateParameter("Id", data.Login, DbType.String);
			var loginParameter = _query.CreateParameter("Login", data.Login, DbType.String);
			var passwordParameter = _query.CreateParameter("Password", data.Password, DbType.String);
			var userNameParameter = _query.CreateParameter("UserName", data.UserName, DbType.String);
			var emailParameter = _query.CreateParameter("Email", data.Email, DbType.String);

			_query.CreateConnection()
				.CreateCommand(DbConstants.UPDATE_USER)
				.AddParameter(idParameter)
				.AddParameter(loginParameter)
				.AddParameter(passwordParameter)
				.AddParameter(userNameParameter)
				.AddParameter(emailParameter)
				.ExecuteQuery();
		}
	}
}
