using DAL.Data.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Concrete
{
	class NotificationReporitory : INotificationRepository
	{

		public void Create(Notification data)
		{
			throw new NotImplementedException();
		}

		public void Delete(int? id)
		{
			throw new NotImplementedException();
		}

		public IReadOnlyCollection<Notification> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Notification> GetNotificationsByCategoryName(string categoryName)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Notification> GetNotificationsByDate(DateTime date)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Notification> GetNotificationsByName(string name)
		{
			throw new NotImplementedException();
		}

		public Notification Read(int? id)
		{
			throw new NotImplementedException();
		}

		public void Update(Notification data)
		{
			throw new NotImplementedException();
		}
	}
}
