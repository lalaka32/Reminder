using BLL.Services.Abstract;
using DAL.Data.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
	public class NotificationService : Service<Notification>, INotificationService
	{
		INotificationRepository _notificationRepository;

		public NotificationService(INotificationRepository notificationRepository) : base(notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}

		public IEnumerable<Notification> GetAllNotifications { get { return _notificationRepository.Repository; } }

		public IEnumerable<Notification> GetNotificationsByCategoryName(string categoryName)
		{
			return _notificationRepository.GetNotificationsByCategoryName(categoryName);
		}

		public IEnumerable<Notification> GetNotificationsByDate(DateTime date)
		{
			return _notificationRepository.GetNotificationsByDate(date);
		}

		public IEnumerable<Notification> GetNotificationsByName(string name)
		{
			return _notificationRepository.GetNotificationsByName(name);
		}
	}
}
