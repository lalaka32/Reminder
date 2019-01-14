using DAL.Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
	public interface IUserService : IService<User>
	{
		IEnumerable<User> GetAllUsers();
		User GetUserByLogin(string login);
	}
}
