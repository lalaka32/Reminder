using DAL.Data.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Concrete
{
	class UserStaticRepository : StaticRepository<User>, IUserRepository
	{
		public UserStaticRepository()
		{
			_repository = new List<User>{
				new User(){ Id = 0,
				 Name = "Petr",
				  Age = 1,
				   LastName = "Bot",
					Password = "FakePass123"
				},
				new User(){ Id = 1,
				 Name = "Ivan",
				  Age = 1,
				   LastName = "Bot",
					Password = "FakePass123"
				}};
		}
	}
}
