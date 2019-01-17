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

			_query.CreateConnection()
				.CreateCommand(DbConstants.CREATE_USER)
				.AddParameter(_query.CreateParameter("Login", data.Login))
				.AddParameter(_query.CreateParameter("Password", data.Password))
				.AddParameter(_query.CreateParameter("UserName", data.UserName))
				.AddParameter(_query.CreateParameter("Email", data.Email))
				.AddParameter(_query.CreateParameter("RoleId", data.Role.Id))
				.ExecuteQuery();
		}

		public void Delete(int? id)
		{
			_query.CreateConnection()
				.CreateCommand(DbConstants.DELETE_USER)
				.AddParameter(_query.CreateParameter("Id", id))
				.ExecuteQuery();
		}

		public User Read(int? id)
		{
			User user =null;

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_USER_BY_ID)
				.AddParameter(_query.CreateParameter("Id", id))
				.ExecuteReader();

			foreach (var item in reader)
			{
				user = ConvertDataToClass(item);
			}

			return user;
		}

		public void Update(User data)
		{
			_query.CreateConnection()
				.CreateCommand(DbConstants.UPDATE_USER)
				.AddParameter(_query.CreateParameter("Id", data.Id, DbType.Int32))
				.AddParameter(_query.CreateParameter("Login", data.Login))
				.AddParameter(_query.CreateParameter("Password", data.Password))
				.AddParameter(_query.CreateParameter("UserName", data.UserName))
				.AddParameter(_query.CreateParameter("Email", data.Email))
				.AddParameter(_query.CreateParameter("RoleId", data.Role.Id))
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

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_USER_BY_LOGIN)
				.AddParameter(_query.CreateParameter("Login", login))
				.ExecuteReader();

			foreach (var item in reader)
			{
				user = ConvertDataToClass(item);
			}

			return user;
		}
	}
}
