using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
	public class OperationInfo
	{
		public bool Successed { get; private set; }
		public string Message { get; private set; }
		public string Property { get; private set; }

		public OperationInfo(bool successed, string message = "", string property = "")
		{
			Successed = successed;
			Message = message;
			Property = property;
		}
	}
}
