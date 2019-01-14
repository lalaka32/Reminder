using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
	public interface IReadableRepository<T>
	{
		IReadOnlyCollection<T> GetAll();

		T Read(int? id);
	}
}
