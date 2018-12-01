
using DAL.Data.Abstract;
using DAL.Data.Concrete;
using StructureMap;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DI
{
	public class DALRegistry : Registry
	{
		public DALRegistry()
		{
			For<INotificationRepository>().Use<StaticNotificationRepository>();
			For<IUserRepository>().Use<UserStaticRepository>();
		}
	}
}
