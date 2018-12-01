﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class User : IStorageble
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string LastName { get; set; }

		public int Age { get; set; }

		public string Password { get; set; }


	}
}