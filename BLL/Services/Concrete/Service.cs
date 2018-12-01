using BLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data.Abstract;

namespace BLL.Services.Concrete
{
	public abstract class Service<T> : IService<T>
	{
		IRepository<T> _repository;

		public Service(IRepository<T> repository)
		{
			_repository = repository;
		}

		public void Create(T data)
		{
			_repository.Create(data);
		}

		public void Delete(T data)
		{
			_repository.Delete(data);
		}

		public T Read(int id)
		{
			return _repository.Read(id);
		}

		public void Update(T data)
		{
			_repository.Update(data);
		}
	}
}
