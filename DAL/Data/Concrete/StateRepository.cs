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
	class StateRepository : IStateRepository
	{
		IConnectionHelper _query;

		public StateRepository(IConnectionHelper sqlFactory)
		{
			_query = sqlFactory;
		}

		StateOfReminder ConvertDataToClass(IDataRecord data)
		{
			StateOfReminder states = new StateOfReminder
			{
				Id = (int)data["Id"],
				Name = (string)data["Name"]
			};
			return states;
		}

		public IReadOnlyCollection<StateOfReminder> GetAll()
		{
			List<StateOfReminder> allStates = new List<StateOfReminder>();

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_ALL_STATES)
				.ExecuteReader();

			foreach (var item in reader)
			{
				var state = ConvertDataToClass(item);

				allStates.Add(state);
			}

			return allStates;
		}

		public StateOfReminder Read(int? id)
		{
			StateOfReminder role = null;

			var reader = _query.CreateConnection()
				.CreateCommand(DbConstants.GET_STATE_BY_ID)
				.AddParameter(_query.CreateParameter("Id", id))
				.ExecuteReader();

			foreach (var item in reader)
			{
				role = ConvertDataToClass(item);
			}

			return role;
		}

	}
}
