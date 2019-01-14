using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
	class ActionService : IActionService
	{
		IActionRepository _actionRepository;

		public ActionService(IActionRepository actionRepository)
		{
			_actionRepository = actionRepository;
		}

		public void Create(ReminderAction data)
		{
			_actionRepository.Create(data);
		}

		public void Delete(int? id)
		{
			_actionRepository.Delete(id);
		}

		public IEnumerable<ReminderAction> GetActionsByReminderId(int id)
		{
			return _actionRepository.GetActionsByReminderId(id);
		}

		public ReminderAction Read(int? id)
		{
			return _actionRepository.Read(id);
		}

		public void Update(ReminderAction data)
		{
			_actionRepository.Update(data);
		}
	}
}
