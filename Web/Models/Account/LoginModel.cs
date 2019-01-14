using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Account
{
	public class LoginModel
	{

		[Required(ErrorMessage = "Enter the value")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}