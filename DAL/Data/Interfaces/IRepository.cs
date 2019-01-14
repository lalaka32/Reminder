using DAL.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
	public interface IRepository<T> : IReadableRepository<T>
	{
		void Create(T data);
		void Update(T data);
		void Delete(int? id);
	}
}
