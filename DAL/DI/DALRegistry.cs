using DAL.Data.Interfaces;
using DAL.Data.Concrete;
using DAL.Helpers.Interfaces;
using DAL.Helpers.Concrete;
using StructureMap.Configuration.DSL;

namespace DAL.DI
{
	public class DALRegistry : Registry
	{
		public DALRegistry()
		{
			For<IConnectionHelper>().Use<ConnectionHelper>();
			For<IReminderRepository>().Use<ReminderReporitory>();
			For<IUserRepository>().Use<UserRepository>();
			For<IRoleRepository>().Use<RoleRepository>();
			For<ICategoryRepository>().Use<CategoryRepository>();
			For<IStateRepository>().Use<StateRepository>();
			For<IActionRepository>().Use<ActionRepository>();
		}
	}
}
