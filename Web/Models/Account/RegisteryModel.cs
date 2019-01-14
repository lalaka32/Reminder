﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Account
{
	public class RegisteryModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		public string Email { get; set; }
	}
}