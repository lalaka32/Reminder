using DAL.Data.Interfaces;
using DAL.Helpers.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Concrete
{
	class RoleRepository : IRoleRepository
	{
		IConnectionHelper _query;

		public RoleRepository(IConnectionHelper sqlFactory)
		{
			_query = sqlFactory;
		}

		public IReadOnlyCollection<Role> GetAll()
		{
			List<Role> allUsers = new List<Role>();

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_ALL_ROLES)
				.ExecuteReader();

			foreach (var item in reader)
			{
				var role = ConvertDataToClass(item);

				allUsers.Add(role);
			}

			return allUsers;
		}

		public Role Read(int? id)
		{
			Role role = null;

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_ROLE_BY_ID)
				.AddParameter(_query.CreateParameter("Id", id))
				.ExecuteReader();

			foreach (var item in reader)
			{
				role = ConvertDataToClass(item);
			}

			return role;
		}

		Role ConvertDataToClass(IDataRecord data)
		{
			Role role = new Role
			{
				Id = (int)data["Id"],
				Name = (string)data["Name"]
			};
			return role;
		}
	}
}
