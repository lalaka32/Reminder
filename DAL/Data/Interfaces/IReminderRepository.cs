using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
	public interface IReminderRepository : IRepository<Reminder>
	{

		IEnumerable<Reminder> GetRemindersByLogin(string login);
	}
}
