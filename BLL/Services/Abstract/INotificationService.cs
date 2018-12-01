using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
	public interface INotificationService : IService<Notification>
	{
		IEnumerable<Notification> GetAllNotifications { get; }

		IEnumerable<Notification> GetNotificationsByName(string name);

		IEnumerable<Notification> GetNotificationsByCategoryName(string categoryName);

		IEnumerable<Notification> GetNotificationsByDate(DateTime date);

	}
}
