using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
	public interface IService<T>
	{
		void Create(T data);
		T Read(int id);
		void Update(T data);
		void Delete(int? id);
	}
}
