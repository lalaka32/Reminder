using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.UserModels
{
	public class CreateUserViewModel
	{
		public int Id { get; set; }

		public int RoleId { get; set; }

		[Required(ErrorMessage = "Enter the login")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Enter the password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Enter the username")]
		[Display(Name ="User name")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Enter the email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}