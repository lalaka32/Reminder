using DAL.Data.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
	public interface IUserService : IService<User>
	{
		IEnumerable<User> GetAllUsers { get; }
	}
}
