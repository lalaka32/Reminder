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
	class CategoryRepository : ICategoryRepository
	{

		IConnectionHelper _helper;

		public CategoryRepository(IConnectionHelper helper)
		{
			_helper = helper;
		}


		public IReadOnlyCollection<CategoryOfReminder> GetAll()
		{
			List<CategoryOfReminder> allUsers = new List<CategoryOfReminder>();

			var reader = _helper.CreateConnection()
				.CreateCommand(DbConstants.GET_ALL_CATEGORIES)
				.ExecuteReader();

			foreach (var item in reader)
			{
				var role = ConvertDataToClass(item);

				allUsers.Add(role);
			}

			return allUsers;
		}

		public CategoryOfReminder Read(int? id)
		{
			CategoryOfReminder role = null;

			var reader = _helper.CreateConnection()
				.CreateCommand(DbConstants.GET_CATEGORY_BY_ID)
				.AddParameter(_helper.CreateParameter("Id", id))
				.ExecuteReader();

			foreach (var item in reader)
			{
				role = ConvertDataToClass(item);
			}

			return role;
		}

		CategoryOfReminder ConvertDataToClass(IDataRecord data)
		{
			CategoryOfReminder category = new CategoryOfReminder
			{
				Id = (int)data["Id"],
				Name = (string)data["Name"]
			};
			return category;
		}
	}
}
