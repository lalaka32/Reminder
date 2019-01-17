using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web.Models.ValidationAttributes;

namespace Web.Models.Reminder
{
	[DateOnlyFuture(ErrorMessage = "Set future date")]
	public class CreateReminderModel
	{
		public int Id { get; set; }

		public string Login { get; set; }

		public int CategoryId { get; set; }

		public string UserName { get; set; }

		[Required( ErrorMessage ="Enter the name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Enter the description")]
		public string Description { get; set; }

		[Display(Name ="Date of creation")]
		public DateTime DateOfCreation { get; set; }

		[Required( ErrorMessage ="Choose date")]
		[DataType(DataType.Date)]
		[Display(Name = "Date of event")]
		public DateTime DateOfEvent { get; set; }

		[Required(ErrorMessage = "Choose time")]
		[DataType(DataType.Time)]
		[Display(Name = "Time of event")]
		public DateTime TimeOfEvent { get; set; }

		[Display(Name = "Picture")]
		public byte[] Picture { get; set; }
	}
}