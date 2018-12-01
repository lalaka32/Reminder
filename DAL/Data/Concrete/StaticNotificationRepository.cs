using DAL.Data.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Concrete
{
	public class StaticNotificationRepository : StaticRepository<Notification>, INotificationRepository
	{
		
		public StaticNotificationRepository()
		{
			_repository  = new List<Notification>{
						new Notification(){
							Id = 0,
							Name = "Get up",
							Category = new Category() { Id = 0, Name = "Routine" },
							Date = DateTime.Now,
							Description = "Enough",
							Doings = new List<Doing>() { new Doing() { Id = 0, Name = "Open eyes" } },
							Image = new Image() { Id = 0, Name = "_get_up" }
						},
						new Notification(){
							Id = 1,
							Name = "Sleep",
							Category = new Category() { Id = 0, Name = "Routine" },
							Date = DateTime.Now,
							Description = "Enough",
							Doings = new List<Doing>() { new Doing() { Id = 0, Name = "Close eyes" } },
							Image = new Image() { Id = 0, Name = "_sleep" }
						}};
		}

		public void DeleteNotificationById(int id)
		{
			_repository.Remove( Read(id) );
		}

		public IEnumerable<Notification> GetNotificationsByCategoryName(string categoryName)
		{
			return _repository.Where(n => n.Category.Name.Contains(categoryName));
		}

		public IEnumerable<Notification> GetNotificationsByDate(DateTime date)
		{
			return _repository.Where(n => n.Date.Date.Equals(date.Date));
		}

		public IEnumerable<Notification> GetNotificationsByName(string name)
		{
			return _repository.Where(n => n.Name.Contains(name));
		}
	}
}
