using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Logger
{
	public interface IFileLogger
	{
		void WriteToFile(string message);
	}
}
