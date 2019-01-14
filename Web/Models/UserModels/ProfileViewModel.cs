using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.UserModels
{
	public class ProfileViewModel
	{
		public int Id { get; set; }

		public int RoleId { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Enter the value")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}