using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class Reminder
	{
		public int ReminderId { get; set; }

		public string Name { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }

		public List<Doing> Doings { get; set; }

		public Category Category { get; set; }

		public Image Image { get; set; }


	}
}
