using BLL.Services.Abstract;
using DAL.Data.Abstract;
using Entities;
using System;
using System.Collections.Generic;

namespace BLL.Services.Concrete
{
	public class UserService : Service<User>, IUserService
	{

		IUserRepository _userRepository;

		public UserService(IUserRepository userRepository) : base(userRepository)
		{
			_userRepository = userRepository;
		}

		public IEnumerable<User> GetAllUsers { get { return _userRepository.GetAll(); } }
	}
}
