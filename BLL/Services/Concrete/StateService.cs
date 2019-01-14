using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
	public class StateService : IStateService
	{
		IStateRepository _repository;
		public StateService(IStateRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<StateOfReminder> GetAllStates()
		{
			return _repository.GetAll();
		}

		public StateOfReminder Read(int? id)
		{
			return _repository.Read(id);
		}
	}
}
