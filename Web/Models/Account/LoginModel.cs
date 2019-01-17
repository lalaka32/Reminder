using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Account
{
	public class LoginModel
	{

		[Required(ErrorMessage = "Enter the login")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Enter the password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}