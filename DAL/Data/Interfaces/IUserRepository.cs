using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Data.Interfaces
{
	public interface IUserRepository : IRepository<User>
	{
		User GetUserByLogin(string login);
	}
}
