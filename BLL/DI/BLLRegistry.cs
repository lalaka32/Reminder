using BLL.Services.Abstract;
using BLL.Services.Concrete;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DI
{
	public class BLLRegistry : Registry
	{
		public BLLRegistry()
		{
			For<INotificationService>().Use<NotificationService>();
			For<IUserService>().Use<UserService>();
		}
	}
}
