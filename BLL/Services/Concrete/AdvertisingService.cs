using BLL.AdvertisingReference;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Advertising = Entities.Concrete.Advertising;
using IAdvertisingService = BLL.Services.Interfaces.IAdvertisingService;

namespace BLL.Services.Concrete
{
	class AdvertisingService : IAdvertisingService
	{

		public Advertising GetAdvertising()
		{
			var channel = new AdvertisingServiceClient();
			var advertising = channel.GetRandomAdvertising();
			Advertising result = new Advertising() { Image = advertising.Picture, Title = advertising.Title };
			return result;
		}
	}
}
