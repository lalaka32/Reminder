using BLL.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
	public interface IAuthorizationService
	{
		OperationInfo Register(User user);
		OperationInfo Authenticate(string login, string password);
		OperationInfo Logout();
		OperationInfo EditProfile(User user);
	}
}
