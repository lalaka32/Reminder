using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;

namespace BLL.Services.Concrete
{
	public class UserService : IUserService
	{

		IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IEnumerable<User> GetAllUsers() { return _userRepository.GetAll(); }

		public void Create(User data)
		{
			_userRepository.Create(data);
		}

		public void Delete(int? id)
		{
			_userRepository.Delete(id);
		}

		public User Read(int? id)
		{
			return _userRepository.Read(id);
		}

		public void Update(User data)
		{
			_userRepository.Update(data);
		}

		public User GetUserByLogin(string login)
		{
			return _userRepository.GetUserByLogin(login);
		}
	}
}
