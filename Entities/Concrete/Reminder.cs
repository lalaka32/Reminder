using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Reminder
	{
		public int Id { get; set; }

		public User User { get; set; }

		public StateOfReminder State { get; set; }

		public CategoryOfReminder Category { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime DateOfCreation { get; set; }

		public DateTime DateOfEvent { get; set; }

		public byte[] Picture { get; set; }


	}
}
