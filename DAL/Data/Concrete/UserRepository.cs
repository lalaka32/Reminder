using DAL.Data.Interfaces;
using DAL.Helpers.Interfaces;
using Entities;
using Entities.Concrete;
using System.Collections.Generic;
using System.Data;

namespace DAL.Data.Concrete
{
	class UserRepository : IUserRepository
	{
		readonly IConnectionHelper _query;

		public UserRepository(IConnectionHelper query)
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
				var user = ConvertDataToClass(item);

				allUsers.Add(user);
			}

			return allUsers;

		}

		public void Create(User data)
		{
			var loginParameter = _query.CreateParameter("Login", data.Login);
			var passwordParameter = _query.CreateParameter("Password", data.Password);
			var userNameParameter = _query.CreateParameter("UserName", data.UserName);
			var emailParameter = _query.CreateParameter("Email", data.Email);
			var roleId = _query.CreateParameter("RoleId", data.Role.Id);

			_query.CreateConnection()
				.CreateCommand(DbConstants.CREATE_USER)
				.AddParameter(loginParameter)
				.AddParameter(passwordParameter)
				.AddParameter(userNameParameter)
				.AddParameter(emailParameter)
				.AddParameter(roleId)
				.ExecuteQuery();
		}

		public void Delete(int? id)
		{
			var idParameter = _query.CreateParameter("Id", id);

			_query.CreateConnection()
				.CreateCommand(DbConstants.DELETE_USER)
				.AddParameter(idParameter)
				.ExecuteQuery();
		}

		public User Read(int? id)
		{
			User user =null;

			var idParameter = _query.CreateParameter("Id", id);

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_USER_BY_ID)
				.AddParameter(idParameter)
				.ExecuteReader();

			foreach (var item in reader)
			{
				user = ConvertDataToClass(item);
			}

			return user;
		}

		public void Update(User data)
		{
			var idParameter = _query.CreateParameter("Id", data.Id, DbType.Int32);
			var loginParameter = _query.CreateParameter("Login", data.Login);
			var passwordParameter = _query.CreateParameter("Password", data.Password);
			var userNameParameter = _query.CreateParameter("UserName", data.UserName);
			var emailParameter = _query.CreateParameter("Email", data.Email);
			var roleId = _query.CreateParameter("RoleId", data.Role.Id);
			var type = idParameter.DbType;
			_query.CreateConnection()
				.CreateCommand(DbConstants.UPDATE_USER)
				.AddParameter(idParameter)
				.AddParameter(loginParameter)
				.AddParameter(passwordParameter)
				.AddParameter(userNameParameter)
				.AddParameter(emailParameter)
				.AddParameter(roleId)
				.ExecuteQuery();
		}

		User ConvertDataToClass(IDataRecord data)
		{
			User user = new User
			{
				Id = (int)data["Id"],
				Email = (string)data["Email"],
				UserName = (string)data["UserName"],
				Login = (string)data["Login"],
				Password = (string)data["Password"],
				Role = new Role()
				{
					Id = (int)data["RoleId"],
					Name = (string)data["RoleName"]
				}
			};
			return user;
		}

		public User GetUserByLogin(string login)
		{
			User user = null;

			var loginParameter = _query.CreateParameter("Login", login);

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_USER_BY_LOGIN)
				.AddParameter(loginParameter)
				.ExecuteReader();

			foreach (var item in reader)
			{
				user = ConvertDataToClass(item);
			}

			return user;
		}
	}
}
