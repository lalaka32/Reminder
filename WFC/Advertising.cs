using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WFC
{
	[DataContract]
	public class Advertising
	{
		[DataMember]
		public byte[] Picture { get; set; }

		[DataMember]
		public string Title { get; set; }
	}
}