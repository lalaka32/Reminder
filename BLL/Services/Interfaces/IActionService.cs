using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
	public interface IActionService : IService<ReminderAction>
	{
		IEnumerable<ReminderAction> GetActionsByReminderId(int id);
	}
}
