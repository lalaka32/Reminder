using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Notification : IStorageble
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime DateOfCreation { get; set; }

		public DateTime DateOfEvent { get; set; }

		public string ImagePath { get; set; }


	}
}
