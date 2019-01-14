using BLL.Services.Interfaces;
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
			For<IReminderService>().Use<ReminderService>();
			For<IUserService>().Use<UserService>();
			For<IRoleService>().Use<RoleService>();
			For<IAuthorizationService>().Use<AuthorizationService>();
			For<ICategoryService>().Use<CategoryService>();
			For<IStateService>().Use<StateService>();
			For<IActionService>().Use<ActionService>();
			For<IAdvertisingService>().Use<AdvertisingService>();
		}
	}
}
