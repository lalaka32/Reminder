using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WFC
{
	
	public class AdvertisingService : IAdvertisingService
	{
		public Advertising GetRandomAdvertising()
		{
			byte[] imageData = null;
			// считываем переданный файл в массив байтов
			imageData = File.ReadAllBytes(@"~/App_Data/Content/visual-studio-2019.jpg");

			Advertising result = new Advertising()
			{
				 Title = "Visual studio 2019",
				 Picture = imageData
			};

			return result;
		}

		
	}
}
