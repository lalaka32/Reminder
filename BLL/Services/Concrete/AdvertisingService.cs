using BLL.Services.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
	class AdvertisingService : IAdvertisingService
	{
		private AdvertisingReference.IAdvertisingService channel;

		public AdvertisingService()
		{
			channel = InitializeChannel();
		}

		public Advertising GetAdvertising()
		{
			var advertising = channel.GetRandomAdvertising();
			Advertising result = new Advertising() { Image = advertising.Picture, Title = advertising.Title };
			return result;
		}

		AdvertisingReference.IAdvertisingService InitializeChannel()
		{

			Uri address = new Uri("http://localhost:50817/AdvertisingService.svc");

			BasicHttpBinding binding = new BasicHttpBinding();

			EndpointAddress endpoint = new EndpointAddress(address);

			ChannelFactory<AdvertisingReference.IAdvertisingService> factory = new ChannelFactory<AdvertisingReference.IAdvertisingService>(binding, endpoint);

			AdvertisingReference.IAdvertisingService channel = factory.CreateChannel();



			return channel;
		}
	}
}
