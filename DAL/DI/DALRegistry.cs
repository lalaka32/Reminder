using DAL.Data.Abstract;
using DAL.Data.Concrete;
using DAL.SqlHelpers.Abstract;
using DAL.SqlHelpers.Concrete;
using StructureMap.Configuration.DSL;

namespace DAL.DI
{
	public class DALRegistry : Registry
	{
		public DALRegistry()
		{
			For<ISqlFactory>().Use<SqlFactory>();
			//For<INotificationRepository>().Use<StaticNotificationRepository>();
			For<IUserRepository>().Use<UserRepository>();
		}
	}
}
