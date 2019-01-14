using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Reminder
{
	public class CreateReminderModel
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public int CategoryId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime DateOfCreation { get; set; }

		[Required( ErrorMessage ="Choose date")]
		[DataType(DataType.Date)]
		public DateTime DateOfEvent { get; set; }

		[Required(ErrorMessage = "Choose time")]
		[DataType(DataType.Time)]
		public DateTime TimeOfEvent { get; set; }

		public byte[] Picture { get; set; }
	}
}