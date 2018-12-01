using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Abstract
{
	public interface IRepository<T> 
	{
		IEnumerable<T> Repository { get; }

		void Create(T data);
		T Read(int id);
		void Update(T data);
		void Delete(T data);

	}
}
