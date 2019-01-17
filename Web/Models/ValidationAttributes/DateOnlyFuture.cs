using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web.Models.Reminder;

namespace Web.Models.ValidationAttributes
{
	public class DateOnlyFutureAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{

			if (value is CreateReminderModel model)
			{
				if (DateTime.Now.DayOfYear < model.DateOfEvent.DayOfYear && DateTime.Now.Year <= model.DateOfEvent.Year)
				{
					return true;
				}
				else if (DateTime.Now.DayOfYear == model.DateOfEvent.DayOfYear && DateTime.Now.Year <= model.DateOfEvent.Year)
				{
					if (model.TimeOfEvent.Hour >= DateTime.Now.Hour && model.TimeOfEvent.Minute > DateTime.Now.Minute)
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}