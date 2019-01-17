using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WFC
{
	
	public class AdvertisingService : IAdvertisingService
	{
		private List<Advertising> _advertisings = new List<Advertising>();

		public AdvertisingService()
		{
			_advertisings.Add(GetAdvertisingFromPicture("visual-studio-2019.jpg", "Visual studio 2019"));
			_advertisings.Add(GetAdvertisingFromPicture("VS-code.png", "Visual studio code"));
			_advertisings.Add(GetAdvertisingFromPicture("asp-net-mvc.jpg", "ASP.NET MVC"));
		}
		public Advertising GetRandomAdvertising()
		{
			Random rnd = new Random();
			return _advertisings[rnd.Next(0,_advertisings.Count)];
		}

		Advertising GetAdvertisingFromPicture(string fileName, string title)
		{
			byte[] imageData = null;
			// считываем переданный файл в массив байтов

			string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "App_Data/Content/" + fileName);
			imageData = File.ReadAllBytes(path);

			Advertising result = new Advertising()
			{
				Title = title,
				Picture = imageData
			};
			return result;
		}
	}
}
