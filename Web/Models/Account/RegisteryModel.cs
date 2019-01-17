using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Account
{
	public class RegisteryModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Enter the login")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Enter the password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Enter the password")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		[Display(Name = "Confirm password")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "User name" )]
		[Required(ErrorMessage = "Enter the user name")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Enter the Email")]
		public string Email { get; set; }
	}
}