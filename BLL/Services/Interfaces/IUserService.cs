using BLL.Infrastructure;
using DAL.Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
	public interface IUserService : IReadableService<User>
	{
		IEnumerable<User> GetAllUsers();
		User GetUserByLogin(string login);

		OperationInfo Create(User data);
		OperationInfo Update(User data);
		OperationInfo Delete(int? data);
	}
}
