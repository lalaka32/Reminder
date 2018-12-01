using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Abstract
{
	public interface INotificationRepository : IRepository<Notification>
	{

		void DeleteNotificationById(int id);

		IEnumerable<Notification> GetNotificationsByName(string name);

		IEnumerable<Notification> GetNotificationsByCategoryName(string categoryName);

		IEnumerable<Notification> GetNotificationsByDate(DateTime date);
	}
}
