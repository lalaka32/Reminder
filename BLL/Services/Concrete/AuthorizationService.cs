using BLL.Infrastructure;
using BLL.Services.Interfaces;
using DAL.Data.Interfaces;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BLL.Services.Concrete
{
	class AuthorizationService : IAuthorizationService
	{
		IUserRepository _userRepository;
		IRoleRepository _roleRepository;

		public AuthorizationService(IUserRepository userRepository, IRoleRepository roleRepository)
		{
			_userRepository = userRepository;
			_roleRepository = roleRepository;
		}

		public OperationInfo Authenticate(string login, string password)
		{
			User user = _userRepository.GetUserByLogin(login);
			if (user == null)
			{
				return new OperationInfo(false, "Wrong login", "Login");
			}
			if (user.Password != password)
			{
				return new OperationInfo(false, "Wrong password");
			}
			SetCookies(user);

			return new OperationInfo(true, "Success");
		}

		private static void SetCookies(User user)
		{
			var httpContext = HttpContext.Current;
			var ticket = new FormsAuthenticationTicket(
			   version: 1,
			   name: user.Login,
			   issueDate: DateTime.Now,
			   expiration: DateTime.Now.AddMinutes(15),
			   isPersistent: true,
			   userData: user.Role.Name);

			var encryptedTicket = FormsAuthentication.Encrypt(ticket);
			var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

			httpContext.Response.Cookies.Add(cookie);
		}

		public OperationInfo Logout()
		{
			FormsAuthentication.SignOut();

			return new OperationInfo(true, "Logout successfull");
		}

		public OperationInfo Register(User user)
		{
			List<User> users = _userRepository.GetAll().ToList();

			if (users.FirstOrDefault(x => x.Login == user.Login) != null)
			{
				return new OperationInfo(false, "Login is occupied");
			}

			if (users.FirstOrDefault(x => x.Email == user.Email) != null)
			{
				return new OperationInfo(false, "Email is occupied");
			}

			user.Role = _roleRepository.Read(LogicConstants.ID_USER_ROLE);

			_userRepository.Create(user);

			SetCookies(user);

			return new OperationInfo(true, "Success");
		}

		public OperationInfo EditProfile(User user)
		{
			List<User> users = _userRepository.GetAll().ToList();

			if (users.FirstOrDefault(x => x.Login == user.Login && x.Id!=user.Id) != null)
			{
				return new OperationInfo(false, "Login is occupied");
			}

			if (users.FirstOrDefault(x => x.Email == user.Email && x.Id != user.Id) != null)
			{
				return new OperationInfo(false, "Email is occupied");
			}

			_userRepository.Update(user);

			return new OperationInfo(true, "Success");
		}
	}
}
