using BLL.Infrastructure;
using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

		public OperationInfo Create(User data)
		{
			var users = _userRepository.GetAll().ToList();

			if (users.FirstOrDefault(x => x.Login == data.Login) != null)
			{
				return new OperationInfo(false, "User with same login exist, please change it", "Login");
			}
			if (users.FirstOrDefault(x => x.Email == data.Email) != null)
			{
				return new OperationInfo(false, "User with same email exist, please change it", "Email");
			}

			_userRepository.Create(data);

			return new OperationInfo(true);
		}

		public OperationInfo Delete(int? id)
		{
			if (id == null || id < 0)
			{
				return new OperationInfo(false, "User with this id not exist");
			}

			_userRepository.Delete(id);

			return new OperationInfo(true);
		}

		public User Read(int? id)
		{
			if (id == null || id < 0)
			{
				return null;
			}
			return _userRepository.Read(id);
		}

		public OperationInfo Update(User data)
		{

			var users = _userRepository.GetAll().ToList();

			if (users.FirstOrDefault(x => x.Login == data.Login && x.Id != data.Id) != null)
			{
				return new OperationInfo(false, "User with same login exist, please change it", "Login");
			}
			if (users.FirstOrDefault(x => x.Email == data.Email && x.Id != data.Id) != null)
			{
				return new OperationInfo(false, "User with same email exist, please change it", "Email");
			}

			_userRepository.Update(data);
			return new OperationInfo(true);
		}

		public User GetUserByLogin(string login)
		{
			if (string.IsNullOrEmpty(login))
			{
				return null;
			}
			return _userRepository.GetUserByLogin(login);
		}
	}
}
