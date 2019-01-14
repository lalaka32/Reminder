using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.ReminderAction
{
	public class ReminderActionViewModel 
	{
		public int Id { get; set; }

		public int IdReminder { get; set; }

		[Required(ErrorMessage ="Enter the value." )]
		public string Description { get; set; }
	}
}