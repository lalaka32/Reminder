using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data.Abstract;
using Entities;
using Entities.Abstract;

namespace DAL.Data.Concrete
{
	public abstract class StaticRepository<T> : IRepository<T> where T : IStorageble
	{
		protected List<T> _repository = new List<T>();

		public IEnumerable<T> Repository { get { return _repository; } }

		public void Create(T data)
		{
			_repository.Add(data);
		}

		public T Read(int id)
		{
			return _repository.Single(n => n.Id == id);
		}

		public void Update(T data)
		{
			var _repositoryData = Read(data.Id);
			_repositoryData = data;
		}

		public void Delete(T data)
		{
			_repository.Remove(data);
		}
	}
}
//List<User> _users;
//public IEnumerable<User> Users { get { return _users; } }

//public StaticRepository()
//{
//	_users = new List<User>() {
//				new User { Id = 1, Name = "John", LastName = "Grenson",
//					Age = 22, Password = "Root123/" },

//				new User { Id = 2, Name = "Ivan", LastName = "Petrov",
//					Age = 22, Password = "Qwert123/" },

//				new User { Id = 3, Name = "Logan", LastName = "Fox",
//					Age = 22, Password = "Asdf123/" },

//				new User { Id = 4, Name = "Arlando", LastName = "Blum",
//					Age = 22, Password = "Zxcv123/" }
//			};
//}