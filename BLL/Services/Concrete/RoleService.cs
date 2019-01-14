using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
	public class RoleService : IRoleService
	{

		IRoleRepository _roleRepository;

		public RoleService(IRoleRepository userRepository)
		{
			_roleRepository = userRepository;
		}

		public IEnumerable<Role> GetAllRoles() { return _roleRepository.GetAll(); }

		public Role Read(int? id)
		{
			return _roleRepository.Read(id);
		}
	}
}
