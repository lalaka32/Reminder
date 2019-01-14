using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
	public interface IService<T> : IReadableService<T>
	{
		void Create(T data);
		void Update(T data);
		void Delete(int? id);
	}
}
